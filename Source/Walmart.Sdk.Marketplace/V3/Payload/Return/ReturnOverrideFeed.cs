namespace Walmart.Sdk.Marketplace.V3.Payload.Return
{
	using System.Collections.Generic;
	using Newtonsoft.Json;


	public class ReturnOverrideFeed
	{
		[JsonProperty("header", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public FeedHeader Header { get; set; }

		[JsonProperty("overrideFeed", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public List<ReturnItemOverride> OverrideFeed { get; set; }
	}
}
