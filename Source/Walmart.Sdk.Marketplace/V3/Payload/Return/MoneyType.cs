
namespace Walmart.Sdk.Marketplace.V3.Payload.Return
{
	using Newtonsoft.Json;

	public class MoneyType
	{
		[JsonProperty("currencyAmount", Required = Newtonsoft.Json.Required.Always)]
		public double CurrencyAmount { get; set; }

		[JsonProperty("currencyUnit", Required = Newtonsoft.Json.Required.Always)]
		public string CurrencyUnit { get; set; }
	}
}
