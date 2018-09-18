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
	using Walmart.Sdk.Marketplace.V3.Payload.Report;
	using Walmart.Sdk.Base.Primitive;
	using Walmart.Sdk.Marketplace.V3.Api.Request;
	using Walmart.Sdk.Base.Serialization;
	using Walmart.Sdk.Marketplace.V3.Payload.Feed;
	using System.IO;
	using System.Linq;

	public class ReportEndpoint : BaseEndpoint
	{
		public ReportEndpoint(ApiClient client) : base(client)
		{
			payloadFactory = new V3.Payload.PayloadFactory();
		}

		public async Task<AvailableReconFilesResponse> GetAvailableReconFiles()
		{
			// to avoid deadlock if this method is executed synchronously
			await new ContextRemover();

			var request = CreateRequest();

			request.EndpointUri = "/v3/report/reconreport/availableReconFiles";

			var response = await client.GetAsync(request);

			var result = await ProcessResponse<AvailableReconFilesResponse>(response);
			return result;
		}

		public async Task<byte[]> GetReconFile(string date)
		{
			// to avoid deadlock if this method is executed synchronously
			await new ContextRemover();

			var request = CreateRequest();

			request.EndpointUri = String.Format("/v3/report/reconreport/reconFile?reportDate={0}", date);
			request.HttpRequest.Headers.Add("Accept", "application/octet-stream");

			var response = await client.GetAsync(request);
			var result = await response.RawResponse.Content.ReadAsByteArrayAsync();
			return result;
		}

		public async Task<string> SaveReconFile(string date, string directoryToSaveCsvTo)
		{
			// to avoid deadlock if this method is executed synchronously
			await new ContextRemover();

			var request = CreateRequest();

			request.EndpointUri = String.Format("/v3/report/reconreport/reconFile?reportDate={0}", date);
			request.HttpRequest.Headers.Add("Accept", "application/octet-stream");

			var response = await client.GetAsync(request);

			var destinationFilePath = string.Empty;

			if(response.RawResponse.Headers.TryGetValues("Content-Disposition", out var contentDispositionValues))
			{
				var contentDispositionHeaderValue = new System.Net.Http.Headers.ContentDispositionHeaderValue(contentDispositionValues.First());
				destinationFilePath = System.IO.Path.Combine(directoryToSaveCsvTo, contentDispositionHeaderValue.FileName);
			}
			else
			{
				destinationFilePath = System.IO.Path.Combine(directoryToSaveCsvTo, string.Format("{0}-recon-report.csv", date));
			}
				
			var result = await response.RawResponse.Content.ReadAsByteArrayAsync();

			System.IO.File.WriteAllBytes(destinationFilePath, result);

			return destinationFilePath;
		}
	}
}
