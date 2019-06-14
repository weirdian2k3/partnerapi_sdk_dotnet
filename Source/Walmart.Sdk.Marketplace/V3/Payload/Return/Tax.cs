namespace Walmart.Sdk.Marketplace.V3.Payload.Return
{
	using Newtonsoft.Json;

	public class Tax
	{
		[JsonProperty("taxName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string TaxName { get; set; }

		[JsonProperty("excessTax", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public MoneyType ExcessTax { get; set; }

		[JsonProperty("taxPerUnit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public MoneyType TaxPerUnit { get; set; }
	}
}
