

namespace Walmart.Sdk.Marketplace.V3.Payload.Return
{
	using System.Collections.Generic;
	using Newtonsoft.Json;

	public class Label
	{
		[JsonProperty("labelImageURL", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string LabelImageURL { get; set; }

		[JsonProperty("carrierInfoList", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public List<CarrierInfo> CarrierInfoList { get; set; }
	}
}
