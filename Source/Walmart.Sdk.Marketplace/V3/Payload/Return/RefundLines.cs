namespace Walmart.Sdk.Marketplace.V3.Payload.Return
{
	using Newtonsoft.Json;

	public class RefundLines
	{
		[JsonProperty("returnOrderLineNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int? ReturnOrderLineNumber { get; set; }
	}
}
