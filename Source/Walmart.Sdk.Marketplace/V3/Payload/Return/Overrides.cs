namespace Walmart.Sdk.Marketplace.V3.Payload.Return
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.Text;

	public class Overrides
	{
		[JsonProperty("isKeepIt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string IsKeepIt { get; set; }

		[JsonProperty("isReturnRestricted", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string IsReturnRestricted { get; set; }

		[JsonProperty("restrictionReason", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string RestrictionReason { get; set; }

		[JsonProperty("returnCenterAlias", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string ReturnCenterAlias { get; set; }

		[JsonProperty("shippingAccountAlias", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string ShippingAccountAlias { get; set; }

		[JsonProperty("shippingFee", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string ShippingFee { get; set; }

		[JsonProperty("restockingFeePercentage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string RestockingFeePercentage { get; set; }
	}
}
