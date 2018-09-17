
namespace Walmart.Sdk.Marketplace.V3.Payload.Return
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.Text;

	public class ReturnOrderLine
	{
		[JsonProperty("returnOrderLineNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int? ReturnOrderLineNumber { get; set; }

		[JsonProperty("salesOderLineNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int? SalesOderLineNumber { get; set; }

		[JsonProperty("returnReason", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string ReturnReason { get; set; }

		[JsonProperty("purchaseOrderId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string PurchaseOrderId { get; set; }

		[JsonProperty("item", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public ItemDetails Item { get; set; }

		[JsonProperty("charges", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public List<Charge> Charges { get; set; }

		[JsonProperty("unitPrice", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public MoneyType UnitPrice { get; set; }

		[JsonProperty("chargeTotals", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public List<ChargeTotal> ChargeTotals { get; set; }

		[JsonProperty("lineQuantityInfo", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public List<LineQuantityInfo> LineQuantityInfo { get; set; }

		[JsonProperty("cancellableQty", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int? CancellableQty { get; set; }

		[JsonProperty("quantity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Quantity Quantity { get; set; }

		[JsonProperty("returnExpectedFlag", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public bool? ReturnExpectedFlag { get; set; }

		[JsonProperty("isFastReplacement", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public bool? IsFastReplacement { get; set; }

		[JsonProperty("isKeepIt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public bool? IsKeepIt { get; set; }

		[JsonProperty("lastItem", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public bool? LastItem { get; set; }

		[JsonProperty("refundedQty", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public double? RefundedQty { get; set; }

		[JsonProperty("rechargeableQty", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public double? RechargeableQty { get; set; }

		[JsonProperty("returnTrackingDetail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public List<ReturnTrackingDetail> ReturnTrackingDetail { get; set; }
	}
}
