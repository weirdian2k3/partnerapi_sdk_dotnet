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

namespace Walmart.Sdk.Marketplace.V2.Api
{
	using System.IO;
	using System.Linq;
	using System.Threading.Tasks;

	public class ReportEndpoint : Base.Primitive.BaseEndpoint
	{
		public ReportEndpoint(Base.Primitive.IEndpointClient apiClient) : base(apiClient)
		{
			payloadFactory = new V2.Payload.PayloadFactory();
		}

		/*follow the logic in Java code from here...https://developer.walmart.com/#/apicenter/marketPlace/v2#getReport     */
		private async Task<string> parseResponse(Base.Http.IResponse response, string folderName)
		{
			System.Net.Http.Headers.HttpContentHeaders headers = response.RawResponse.Content.Headers;
			string fileDir = null;
			using (Stream inputStream = await response.RawResponse.Content.ReadAsStreamAsync())
			{
				if ((response.StatusCode == System.Net.HttpStatusCode.OK) && (headers.ContentLength > 0))
				{
					try
					{
						var header = headers.GetValues("Content-Disposition").First();
						if ((header != null) && (!header.Equals("")))
						{
							var length = header.Length;
							var start = header.IndexOf("filename=");
							var fileName = header.Substring(start, length - start);
							var str = fileName.Split('=');
							var dir = folderName + str[1];
							using (Stream fileStream = new FileStream(dir, FileMode.Create, FileAccess.Write))
							{
								inputStream.CopyTo(fileStream);
							}
							fileDir = dir;
						}
					}
					catch (System.Exception ex)
					{
						throw new Base.Exception.InvalidValueException("Error " + ex.Message);
					}
				}
			}
			return fileDir;
		}
		public async Task<string> GetItemReport(string folderName)
		{
			Base.Http.Request request = CreateRequest();
			request.EndpointUri = "/v2/getReport?type=item";
			Base.Http.IResponse response = await client.GetAsync(request);
			return await parseResponse(response, folderName);
		}

		public async Task<string> GetBuyBoxReport(string folderName)
		{
			Base.Http.Request request = CreateRequest();
			request.EndpointUri = "/v2/getReport?type=buybox";
			Base.Http.IResponse response = await client.GetAsync(request);
			return await parseResponse(response, folderName);
		}
		public async Task<string> GetCPAReport(string folderName)
		{
			Base.Http.Request request = CreateRequest();
			request.EndpointUri = "/v2/getReport?type=cpa";
			Base.Http.IResponse response = await client.GetAsync(request);
			return await parseResponse(response, folderName);
		}

	}
}
