

namespace Walmart.Sdk.Marketplace.V3.Payload.Return
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.Text;

	public class ReturnLineGroup
	{
		[JsonProperty("groupNo", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int? GroupNo { get; set; }

		[JsonProperty("returnLines", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public List<ReturnOrderLineGroup> ReturnLines { get; set; }

		[JsonProperty("labels", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public List<Label> Labels { get; set; }

		[JsonProperty("returnExpectedFlag", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public bool? ReturnExpectedFlag { get; set; }
	}
}
