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

namespace Walmart.Sdk.Marketplace.E2ETests.V3
{
	using System.Reflection;
	using System.Threading.Tasks;
	using Walmart.Sdk.Marketplace.V3.Api;
	using Walmart.Sdk.Marketplace.V3.Api.Exception;
	using Walmart.Sdk.Marketplace.V3.Payload.Feed;
	using Xunit;

	public class ItemEndpointTests : BaseE2ETest
	{
		private readonly ItemEndpoint itemApi;

		public ItemEndpointTests()
		{
			itemApi = new ItemEndpoint(client);
		}

		[Fact]
		public async Task ReceiveItemDetails()
		{
			ItemResponses result = await itemApi.GetAllItems();
			Assert.IsType<ItemResponses>(result);
			Assert.True(result.ItemResponse.Count == 10);
			foreach (ItemResponse item in result.ItemResponse)
			{
				Assert.True(item.Price.Amount > 0);
				Assert.False(string.IsNullOrEmpty(item.Sku));
				Assert.False(string.IsNullOrEmpty(item.Gtin));
				Assert.False(string.IsNullOrEmpty(item.Wpid));
			}
		}

		[Fact]
		public async Task UploadNewItems()
		{
			Assembly assembly = typeof(ItemEndpointTests).GetTypeInfo().Assembly;
			var assemblyName = assembly.GetName().Name;
			using (System.IO.Stream stream = assembly.GetManifestResourceStream(assemblyName + ".V3.requestStub.itemFeed.xml"))
			{
				FeedAcknowledgement result = await itemApi.BulkItemsUpdate(stream);
				Assert.IsType<FeedAcknowledgement>(result);
				Assert.True(result.FeedId.Length > 0);
			}
		}

		[Fact(Skip = "item creation issue")]
		public void RetireAnyItem()
		{
			// need a way to create new item on test start up
			// right now it's async with a high SLA
			// so we may wait too long before we can start test
		}

		[Fact]
		public async Task RequestItemByMerchantSku()
		{
			ItemResponses latestSku = await itemApi.GetAllItems(1, 10);
			Assert.IsType<ItemResponses>(latestSku);
			Assert.True(latestSku.ItemResponse.Count == 1);

			ItemResponse oneSku = await itemApi.GetItem(latestSku.ItemResponse[0].Sku);
			Assert.IsType<ItemResponse>(oneSku);
			Assert.True(latestSku.ItemResponse.Count == 1);
			Assert.Equal(latestSku.ItemResponse[0].Sku, oneSku.Sku);
			Assert.Equal(latestSku.ItemResponse[0].Price.Amount, oneSku.Price.Amount);
			Assert.Equal(latestSku.ItemResponse[0].ProductName, oneSku.ProductName);
		}

		[Fact]
		public async Task ReturnErrorForInvalidSku()
		{
			// there is a bug in API, it doesn't have ns2 for error response
			await Assert.ThrowsAsync<ApiException>(
			    () => itemApi.GetItem("invalid-sku-gonna-fail")
			);
		}
	}
}
