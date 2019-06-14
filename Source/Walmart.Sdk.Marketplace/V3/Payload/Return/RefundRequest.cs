namespace Walmart.Sdk.Marketplace.V3.Payload.Return
{
	using System.Collections.Generic;
	using Newtonsoft.Json;

	public class RefundRequest
	{
		[JsonProperty("returnOrderId", Required = Newtonsoft.Json.Required.Always)]
		public string ReturnOrderId { get; set; }

		[JsonProperty("customerOrderId", Required = Newtonsoft.Json.Required.Always)]
		public string CustomerOrderId { get; set; }

		[JsonProperty("refundLines", Required = Newtonsoft.Json.Required.Always)]
		public List<RefundLine> RefundLines { get; set; } = new List<RefundLine>();
	}
}
