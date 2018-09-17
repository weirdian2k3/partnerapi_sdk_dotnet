using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Walmart.Sdk.Marketplace.V3.Payload.Return
{
	public class RefundOverrides
	{
		[JsonProperty("applyShippingFee", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string ApplyShippingFee { get; set; }

		[JsonProperty("restockingFeePercentage", Required = Newtonsoft.Json.Required.Always)]
		public string RestockingFeePercentage { get; set; }

		[JsonProperty("overrideReason", Required = Newtonsoft.Json.Required.Always)]
		public string OverrideReason { get; set; }
	}
}
