
namespace Walmart.Sdk.Marketplace.V3.Payload.Return
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.Text;

	public class ReturnOrder
	{
		[JsonProperty("returnOrderId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string ReturnOrderId { get; set; }

		[JsonProperty("customerEmailId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string CustomerEmailId { get; set; }

		[JsonProperty("customerName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public CustomerName CustomerName { get; set; }

		[JsonProperty("customerOrderId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string CustomerOrderId { get; set; }

		[JsonProperty("returnOrderDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public System.DateTime? ReturnOrderDate { get; set; }

		[JsonProperty("returnByDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public System.DateTime? ReturnByDate { get; set; }

		[JsonProperty("returnMode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string ReturnMode { get; set; }

		[JsonProperty("refundMode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string RefundMode { get; set; }

		[JsonProperty("totalRefundAmount", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public MoneyType TotalRefundAmount { get; set; }

		[JsonProperty("returnLineGroups", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public List<ReturnLineGroup> ReturnLineGroups { get; set; }

		[JsonProperty("returnOrderLines", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public List<ReturnOrderLine> ReturnOrderLines { get; set; }
	}
}
