
namespace Walmart.Sdk.Marketplace.V3.Payload.Return
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.Text;

	public class ItemDetails
	{
		[JsonProperty("sku", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Sku { get; set; }

		[JsonProperty("productName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string ProductName { get; set; }

		[JsonProperty("itemWeight", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Quantity ItemWeight { get; set; }
	}
}
