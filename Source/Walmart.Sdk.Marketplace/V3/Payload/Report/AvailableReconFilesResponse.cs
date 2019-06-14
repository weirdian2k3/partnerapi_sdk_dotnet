
namespace Walmart.Sdk.Marketplace.V3.Payload.Report
{
	using System.Collections.Generic;
	using Newtonsoft.Json;

	public class AvailableReconFilesResponse
	{
		[JsonProperty("availableApReportDates", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public List<string> AvailableApReportDates { get; set; }
	}
}
