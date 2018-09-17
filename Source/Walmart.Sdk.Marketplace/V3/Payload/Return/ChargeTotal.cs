namespace Walmart.Sdk.Marketplace.V3.Payload.Return
{
	using Newtonsoft.Json;

	public class ChargeTotal
	{
		[JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
		public string Name { get; set; }

		[JsonProperty("value", Required = Newtonsoft.Json.Required.Always)]
		public MoneyType Value { get; set; } = new MoneyType();
	}
}
