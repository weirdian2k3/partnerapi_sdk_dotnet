/**
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

namespace Walmart.Sdk.Marketplace.V3.Api
{
	using System;
	using System.Threading.Tasks;
	using Walmart.Sdk.Base.Http;
	using Walmart.Sdk.Marketplace.V3.Payload.Return;
	using Walmart.Sdk.Base.Primitive;
	using Walmart.Sdk.Marketplace.V3.Api.Request;
	using Walmart.Sdk.Base.Serialization;
	using Walmart.Sdk.Marketplace.V3.Payload.Feed;
	using System.IO;

	public class ReturnEndpoint : BaseEndpoint
	{
		private enum ReturnStatus
		{
			INITIATED,
			DELIVERED,
			COMPLETED
		}

		protected FeedEndpoint feedApi;

		public ReturnEndpoint(ApiClient client) : base(client)
		{
			feedApi = new FeedEndpoint(apiClient);
			payloadFactory = new V3.Payload.PayloadFactory();
		}

		public async Task<ReturnsListType> GetReturn(string returnOrderId)
		{
			return await GetAllReturns(returnOrderId: returnOrderId);
		}

		public async Task<ReturnsListType> GetReturns(string customerOrderId)
		{
			return await GetAllReturns(customerOrderId: customerOrderId);
		}

		public async Task<ReturnsListType> GetReturns(DateTime returnCreationStartDate, DateTime returnCreationEndDate, int limit)
		{
			return await GetAllReturns(returnCreationStartDate: returnCreationStartDate, returnCreationEndDate: returnCreationEndDate, limit: limit);
		}

		private async Task<ReturnsListType> GetAllReturns(string returnOrderId = null,
														 string customerOrderId = null,
														 DateTime? returnCreationStartDate = null,
														 DateTime? returnCreationEndDate = null,
														 int limit = 0,
														 ReturnStatus? status = null)
		{
			// to avoid deadlock if this method is executed synchronously
			await new ContextRemover();

			var request = CreateRequest();

			request.EndpointUri = "/v3/returns";

			if (limit < 1) limit = 1;
			if (limit > 200) limit = 200;

			request.QueryParams.Add("limit", limit.ToString());

			if (!string.IsNullOrWhiteSpace(returnOrderId)) request.QueryParams.Add("returnOrderId", returnOrderId.ToString());
			if (!string.IsNullOrWhiteSpace(customerOrderId)) request.QueryParams.Add("customerOrderId", customerOrderId.ToString());

			if (returnCreationStartDate.HasValue &&
				returnCreationEndDate.HasValue)
			{
				request.QueryParams.Add("returnCreationStartDate", returnCreationStartDate.Value.ToString("yyyy-MM-dd"));
				request.QueryParams.Add("returnCreationEndDate", returnCreationEndDate.Value.ToString("yyyy-MM-dd"));
			}

			if (status.HasValue)
			{
				request.QueryParams.Add("status", Enum.GetName(typeof(ReturnStatus), status.Value));
			}

			var response = await client.GetAsync(request);

			var result = await ProcessResponse<ReturnsListType>(response);
			return result;
		}

		public async Task<RefundResponse> IssueRefund(string returnOrderId, RefundRequest refundRequest)
		{
			// to avoid deadlock if this method is executed synchronously
			await new ContextRemover();

			var request = CreateRequest();

			request.EndpointUri = String.Format("/v3/returns/{0}/refund", returnOrderId);
			request.AddPayload(GetSerializer().Serialize(refundRequest));

			var response = await client.PostAsync(request);
			var result = await ProcessResponse<RefundResponse>(response);
			return result;
		}

		public async Task<FeedAcknowledgement> BulkItemsOverride(Stream stream)
		{
			return await feedApi.UploadFeed(stream, V3.Payload.FeedType.RETURNS_OVERRIDES);
		}

		public async Task<FeedAcknowledgement> BulkItemsOverride(ReturnOverrideFeed feed)
		{
			var feedString = GetSerializer().Serialize(feed);
			using (var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(feedString)))
			{
				return await feedApi.UploadFeed(stream, V3.Payload.FeedType.RETURNS_OVERRIDES);
			}
		}
	}
}
