namespace Walmart.Sdk.Marketplace.V3.Payload.Return
{
	using Newtonsoft.Json;

	public class RefundLine
	{
		[JsonProperty("returnOrderLineNumber", Required = Newtonsoft.Json.Required.Always)]
		public int ReturnOrderLineNumber { get; set; }

		[JsonProperty("overrides", Required = Newtonsoft.Json.Required.Always)]
		public RefundOverrides Overrides { get; set; } = new RefundOverrides();
	}
}
