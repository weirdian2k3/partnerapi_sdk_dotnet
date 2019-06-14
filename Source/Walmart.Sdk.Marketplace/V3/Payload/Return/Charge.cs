

namespace Walmart.Sdk.Marketplace.V3.Payload.Return
{
	using System.Collections.Generic;
	using Newtonsoft.Json;

	public class Charge
	{
		[JsonProperty("chargeCategory", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string ChargeCategory { get; set; }

		[JsonProperty("chargeName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string ChargeName { get; set; }

		[JsonProperty("chargePerUnit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public MoneyType ChargePerUnit { get; set; }

		[JsonProperty("isDiscount", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public bool? IsDiscount { get; set; }

		[JsonProperty("isBillable", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public bool? IsBillable { get; set; }

		[JsonProperty("tax", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public List<Tax> Tax { get; set; }

		[JsonProperty("excessCharge", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public MoneyType ExcessCharge { get; set; }
	}
}
