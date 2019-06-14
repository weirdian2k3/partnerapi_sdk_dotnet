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

namespace Walmart.Sdk.Marketplace.V2.Api
{
	using System;
	using System.Threading.Tasks;
	using Walmart.Sdk.Base.Http;
	using Walmart.Sdk.Base.Primitive;
	using Walmart.Sdk.Marketplace.V2.Api.Request;
	using Walmart.Sdk.Marketplace.V2.Payload.Order;

	public class OrderEndpoint : BaseEndpoint
	{
		private enum OrderAction
		{
			Ack,
			Cancel,
			Refund,
			Shipping
		}

		public OrderEndpoint(ApiClient client) : base(client)
		{
			payloadFactory = new V2.Payload.PayloadFactory();
		}

		public async Task<OrdersListType> GetAllReleasedOrders(DateTime createdStartDate, DateTime createdEndDate, int limit = 20)
		{
			// to avoid deadlock if this method is executed synchronously
			await new ContextRemover();

			Base.Http.Request request = CreateRequest();

			request.EndpointUri = "/v2/orders/released";

			if (limit < 1)
			{
				limit = 1;
			}

			if (limit > 200)
			{
				limit = 200;
			}

			request.QueryParams.Add("limit", limit.ToString());
			request.QueryParams.Add("createdStartDate", createdStartDate.ToString("yyyy-MM-dd"));
			request.QueryParams.Add("createdEndDate", createdEndDate.ToString("yyyy-MM-dd"));

			IResponse response = await client.GetAsync(request);
			OrdersListType result = await ProcessResponse<OrdersListType>(response);
			return result;
		}

		public async Task<OrdersListType> GetAllReleasedOrders(string nextCursor)
		{
			// to avoid deadlock if this method is executed synchronously
			await new ContextRemover();

			Base.Http.Request request = CreateRequest();
			request.EndpointUri = string.Format("/v2/orders/released/{0}", nextCursor);
			IResponse response = await client.GetAsync(request);
			OrdersListType result = await ProcessResponse<OrdersListType>(response);
			return result;
		}

		public async Task<Order> GetOrderById(string purchaseOrderId)
		{
			// avoiding deadlock if client execute this method synchronously
			await new ContextRemover();

			Base.Http.Request request = CreateRequest();
			request.EndpointUri = string.Format("/v2/orders/{0}", purchaseOrderId);
			IResponse response = await client.GetAsync(request);
			Order result = await ProcessResponse<Order>(response);
			return result;
		}

		public async Task<OrdersListType> GetAllOrders(OrderFilter filter)
		{
			Base.Http.Request request = CreateRequest();
			filter.FullfilRequest(request);
			request.EndpointUri = "/v2/orders";
			IResponse response = await client.GetAsync(request);
			OrdersListType result = await ProcessResponse<OrdersListType>(response);
			return result;
		}

		public async Task<OrdersListType> GetAllOrders(string nextCursor)
		{
			Base.Http.Request request = CreateRequest();
			request.EndpointUri = string.Format("/v2/orders/{0}", nextCursor);
			IResponse response = await client.GetAsync(request);
			OrdersListType result = await ProcessResponse<OrdersListType>(response);
			return result;
		}

		private async Task<IResponse> UpdateOrder(string purchaseOrderId, OrderAction desiredAction, System.IO.Stream stream = null)
		{
			var action = "";
			switch (desiredAction)
			{
				case OrderAction.Ack:
					action = "acknowledge";
					break;
				case OrderAction.Cancel:
					action = "cancel";
					break;
				case OrderAction.Refund:
					action = "refund";
					break;
				case OrderAction.Shipping:
					action = "shipping";
					break;
				default:
					throw new Base.Exception.InvalidValueException("Unknown order action provided >" + action.ToString() + "<");
			}
			Base.Http.Request request = CreateRequest();
			if (stream != null)
			{
				request.AddMultipartContent(stream);
			}
			request.EndpointUri = string.Format("/v2/orders/{0}/{1}", purchaseOrderId, action);
			IResponse response = await client.PostAsync(request);
			return response;
		}

		public async Task<Order> AckOrder(string purchaseOrderId)
		{
			IResponse response = await UpdateOrder(purchaseOrderId, OrderAction.Ack);
			Order result = await ProcessResponse<Order>(response);
			return result;
		}

		public async Task<Order> CancelOrderLines(string purchaseOrderId, System.IO.Stream stream)
		{
			IResponse response = await UpdateOrder(purchaseOrderId, OrderAction.Cancel);
			Order result = await ProcessResponse<Order>(response);
			return result;
		}

		public async Task<Order> RefundOrderLines(string purchaseOrderId, System.IO.Stream stream)
		{
			IResponse response = await UpdateOrder(purchaseOrderId, OrderAction.Refund);
			Order result = await ProcessResponse<Order>(response);
			return result;
		}

		public async Task<Order> ShippingUpdates(string purchaseOrderId, System.IO.Stream stream)
		{
			IResponse response = await UpdateOrder(purchaseOrderId, OrderAction.Shipping);
			Order result = await ProcessResponse<Order>(response);
			return result;
		}
	}
}
