﻿/**
Copyright (c) 2018-present, Walmart Inc.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

namespace Walmart.Sdk.Marketplace.IntegrationTests.V2
{
	using System;
	using System.Linq;
	using System.Threading.Tasks;
	using Walmart.Sdk.Marketplace.V2.Api.Request;
	using Walmart.Sdk.Marketplace.V2.Payload.Order;
	using Xunit;

	public class OrderEndpointTests : BaseIntegrationTest
	{
		private readonly Marketplace.V2.Api.OrderEndpoint orderApi;

		public OrderEndpointTests()
		{
			var config = new Marketplace.ClientConfig("test", "test-key");
			var apiClient = new Marketplace.ApiClient(config)
			{
				SimulationEnabled = true
			};
			orderApi = new Marketplace.V2.Api.OrderEndpoint(apiClient);
		}

		[Fact]
		public async Task CanFetchOneOrder()
		{
			Order result = await orderApi.GetOrderById("test");
			Assert.IsType<Order>(result);
			Assert.True(result.PurchaseOrderId.Length > 0);
			Assert.True(result.OrderLines.Lines.Count > 0);
			// checking children objects
			// it's very easy to screw up deserialization of these objects
			// so make sure they were parsed correctly
			Assert.True(result.OrderLines.Lines[0].Charges.Count() > 0);
			Assert.True(result.OrderLines.Lines[0].Charges[0].ChargeName.Length > 0);
			Assert.True(result.OrderLines.Lines[0].Charges[0].ChargeType.Length > 0);
			Assert.True(result.OrderLines.Lines[0].OrderLineStatuses.Count() > 0);
			Assert.True(result.OrderLines.Lines[0].OrderLineStatuses[0].Status == OrderLineStatusValueType.Acknowledged);
			Assert.True(result.OrderLines.Lines[0].OrderLineStatuses[0].StatusQuantity.Amount.Length > 0);
			Assert.True(result.OrderLines.Lines[0].OrderLineStatuses[0].StatusQuantity.UnitOfMeasurement.Length > 0);
		}

		[Fact]
		public async Task GetListOfReleasedOrdersWithPagination()
		{
			var startDate = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, 01);
			var endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);
			var pageSize = 20;
			OrdersListType firstPage = await orderApi.GetAllReleasedOrders(startDate, endDate, pageSize);
			Assert.True(firstPage.Elements.Orders.Count > 0);
			Assert.True(firstPage.Meta.NextCursor.Length > 0);
			Assert.True(firstPage.Meta.TotalCount > firstPage.Elements.Orders.Count);

			OrdersListType secondPage = await orderApi.GetAllReleasedOrders(firstPage.Meta.NextCursor);
			Assert.True(secondPage.Elements.Orders.Count > 0);
			Assert.True(secondPage.Meta.NextCursor.Length > 0);
			Assert.True(secondPage.Meta.TotalCount > secondPage.Elements.Orders.Count);
		}

		[Fact]
		public async Task CanFilterAllOrders()
		{
			var filter = new OrderFilter
			{
				CreatedEndDate = DateTime.Now,
				CreatedStartDate = new DateTime(DateTime.Now.Year - 2, DateTime.Now.Month, 1),
				ToExpectedShipDate = DateTime.Now,
				FromExpectedShipDate = new DateTime(DateTime.Now.Year - 2, DateTime.Now.Month, 1),
				CustomerOrderId = "test",
				PurchaseOrderId = "test",
				Status = OrderLineStatusValueType.Shipped,
				Limit = 20
			};

			OrdersListType firstPage = await orderApi.GetAllOrders(filter);
			Assert.IsType<OrdersListType>(firstPage);
			Assert.True(firstPage.Elements.Orders.Count > 0);
		}

		[Fact]
		public async Task CanAcknowledgeOrder()
		{
			Order result = await orderApi.AckOrder("test");
			Assert.IsType<Order>(result);
		}

		[Fact]
		public async Task CancelOrderLinesOnSpecificOrder()
		{
			Order result = await orderApi.CancelOrderLines("test", GetRequestStub("V2.requestStub.cancelOrderLines"));
			Assert.IsType<Order>(result);
		}

		[Fact]
		public async Task SubmitOrderRefundForSpecificOrder()
		{
			Order result = await orderApi.RefundOrderLines("test", GetRequestStub("V2.requestStub.refundOrderLines"));
			Assert.IsType<Order>(result);
		}

		[Fact]
		public async Task SendShippingUpdatesForSpecificOrder()
		{
			Order result = await orderApi.ShippingUpdates("test", GetRequestStub("V2.requestStub.shippingUpdates"));
			Assert.IsType<Order>(result);
		}

		[Fact]
		public async Task InvalidOrderIdThrows404()
		{
			await Assert.ThrowsAsync<Walmart.Sdk.Marketplace.V2.Api.Exception.ApiException>(
			    () => orderApi.GetOrderById("wrong-purchase-id")
			);
		}
	}
}
