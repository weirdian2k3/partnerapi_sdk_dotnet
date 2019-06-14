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

namespace Walmart.Sdk.Marketplace.E2ETests.V2
{
	using System.IO;
	using Walmart.Sdk.Marketplace.V2.Api;
	using Xunit;

	public class ReportEndpointTests : BaseE2ETest
	{
		private ReportEndpoint reportApi;

		public ReportEndpointTests()
		{
			reportApi = new ReportEndpoint(client);
		}

		[Fact]
		public async void GetItemReport()
		{
			var folderName = Directory.GetCurrentDirectory() + @"\";
			var result = await reportApi.GetItemReport(folderName);
			Assert.True(File.Exists(result));
		}

		[Fact]
		public async void GetBuyBoxReport()
		{
			var folderName = Directory.GetCurrentDirectory() + @"\";
			var result = await reportApi.GetBuyBoxReport(folderName);
			Assert.True(File.Exists(result));
		}

		[Fact]
		public async void GetCPAReport()
		{
			var folderName = Directory.GetCurrentDirectory() + @"\";
			var result = await reportApi.GetCPAReport(folderName);
			Assert.True(File.Exists(result));
		}

	}
}
