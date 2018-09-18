
namespace Walmart.Sdk.Marketplace.V3.Payload.Report
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.Text;

	public class AvailableReconFilesResponse
	{
		[JsonProperty("availableApReportDates", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public List<string> AvailableApReportDates { get; set; }
	}
}
