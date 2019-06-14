namespace Walmart.Sdk.Marketplace.V3.Payload.Return
{
	using System.Collections.Generic;
	using Newtonsoft.Json;

	public class RefundResponse
	{
		[JsonProperty("returnOrderId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string ReturnOrderId { get; set; }

		[JsonProperty("customerOrderId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string CustomerOrderId { get; set; }

		[JsonProperty("refundLines", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public List<RefundLines> RefundLines { get; set; }
	}
}
