namespace Walmart.Sdk.Marketplace.V3.Payload.Return
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.Text;

	public class ReturnItemOverride
	{
		[JsonProperty("sku", Required = Newtonsoft.Json.Required.Always)]
		public string Sku { get; set; }

		[JsonProperty("overrides", Required = Newtonsoft.Json.Required.Always)]
		public Overrides Overrides { get; set; } = new Overrides();
	}
}
