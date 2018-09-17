

namespace Walmart.Sdk.Marketplace.V3.Payload.Return
{
	using Newtonsoft.Json;
	using System.Collections.Generic;

	public class ReturnsListType
	{
		[JsonProperty("meta", Required = Newtonsoft.Json.Required.Always)]
		public Meta Meta { get; set; } = new Meta();

		[JsonProperty("returnOrders", Required = Newtonsoft.Json.Required.Always)]
		public List<ReturnOrder> ReturnOrders { get; set; }
	}


	public class Meta
	{
		[JsonProperty("totalCount", Required = Newtonsoft.Json.Required.Always)]
		public int TotalCount { get; set; }

		[JsonProperty("limit", Required = Newtonsoft.Json.Required.Always)]
		public int Limit { get; set; }

		[JsonProperty("nextCursor", Required = Newtonsoft.Json.Required.Always)]
		public string NextCursor { get; set; }
	}
}
