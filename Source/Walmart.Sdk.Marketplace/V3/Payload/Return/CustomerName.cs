
namespace Walmart.Sdk.Marketplace.V3.Payload.Return
{
	using Newtonsoft.Json;

	public class CustomerName
	{
		[JsonProperty("firstName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string FirstName { get; set; }

		[JsonProperty("lastName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string LastName { get; set; }
	}
}
