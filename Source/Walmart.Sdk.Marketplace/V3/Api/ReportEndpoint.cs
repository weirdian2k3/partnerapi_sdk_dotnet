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
	using System.IO;
	using System.Linq;
	using System.Net.Http.Headers;
	using System.Threading.Tasks;
	using Walmart.Sdk.Base.Http;
	using Walmart.Sdk.Base.Primitive;
	using Walmart.Sdk.Marketplace.V3.Payload.Report;

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

			Base.Http.Request request = CreateRequest();

			request.EndpointUri = "/v3/report/reconreport/availableReconFiles";

			IResponse response = await client.GetAsync(request);

			AvailableReconFilesResponse result = await ProcessResponse<AvailableReconFilesResponse>(response);
			return result;
		}

		public async Task<byte[]> GetReconFile(string date)
		{
			// to avoid deadlock if this method is executed synchronously
			await new ContextRemover();

			Base.Http.Request request = CreateRequest();

			request.EndpointUri = string.Format("/v3/report/reconreport/reconFile?reportDate={0}", date);
			request.HttpRequest.Headers.Add("Accept", "application/octet-stream");

			IResponse response = await client.GetAsync(request);
			var result = await response.RawResponse.Content.ReadAsByteArrayAsync();
			return result;
		}

		private async Task<string> SaveReportFile(IResponse response, string directoryToSaveTo)
		{
			var destinationFilePath = string.Empty;

			if (!response.RawResponse.Headers.TryGetValues("Content-Disposition", out System.Collections.Generic.IEnumerable<string> contentDispositionValues))
			{
				throw new InvalidDataException("Unable to pull filename from Content-Disposition");
			}

			var contentDispositionHeaderValue = new ContentDispositionHeaderValue(contentDispositionValues.First());
			destinationFilePath = Path.Combine(directoryToSaveTo, contentDispositionHeaderValue.FileName);

			using (Stream responseStream = await response.RawResponse.Content.ReadAsStreamAsync())
			{
				using (var fileStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
				{
					await responseStream.CopyToAsync(fileStream);
				}
			}

			return destinationFilePath;
		}

		public async Task<string> SaveReconFile(string date, string directoryToSaveCsvTo)
		{
			// to avoid deadlock if this method is executed synchronously
			await new ContextRemover();

			Base.Http.Request request = CreateRequest();

			request.EndpointUri = string.Format("/v3/report/reconreport/reconFile?reportDate={0}", date);
			request.HttpRequest.Headers.Add("Accept", "application/octet-stream");

			IResponse response = await client.GetAsync(request);

			var destinationFilePath = await SaveReportFile(response, directoryToSaveCsvTo);

			return destinationFilePath;
		}
	}
}
