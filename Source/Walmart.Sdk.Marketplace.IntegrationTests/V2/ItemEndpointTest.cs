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

namespace Walmart.Sdk.Marketplace.IntegrationTests.V2
{
	using System.Threading.Tasks;
	using Walmart.Sdk.Marketplace.V2.Api;
	using Walmart.Sdk.Marketplace.V2.Payload.Feed;
	using Walmart.Sdk.Marketplace.V2.Payload.Item;
	using Xunit;

	public class ItemEndpointTests : BaseIntegrationTest
	{
		private readonly ItemEndpoint itemApi;

		public ItemEndpointTests()
		{
			var config = new Marketplace.ClientConfig("test", "test-key");
			var apiClient = new Marketplace.ApiClient(config)
			{
				SimulationEnabled = true
			};
			itemApi = new Marketplace.V2.Api.ItemEndpoint(apiClient);
		}

		[Fact]
		public async Task UpdateItemsInBulk()
		{
			System.IO.Stream stream = GetRequestStub("V2.requestStub.itemFeed");
			FeedAcknowledgement result = await itemApi.BulkItemsUpdate(stream);
			Assert.IsType<FeedAcknowledgement>(result);
			Assert.NotEmpty(result.FeedId);
		}

		[Fact]
		public async Task GetOneSpecificItem()
		{
			ItemView result = await itemApi.GetItem("test");
			Assert.IsType<ItemView>(result);
			Assert.True(result.Sku.Length > 0);
			Assert.True(result.ProductName.Length > 0);
			Assert.True(result.Gtin.Length > 0);
		}

		[Fact]
		public async Task RetireOneSpecificItem()
		{
			ItemRetireResponse result = await itemApi.RetireItem("test");
			Assert.True(result.Sku.Length > 0);
		}

		[Fact]
		public async Task GetListOfItems()
		{
			ItemViewList result = await itemApi.GetAllItems();
			Assert.IsType<ItemViewList>(result);
			foreach (ItemView item in result.Items)
			{
				Assert.IsType<ItemView>(item);
				Assert.True(item.Sku.Length > 0);
			}
		}
	}
}