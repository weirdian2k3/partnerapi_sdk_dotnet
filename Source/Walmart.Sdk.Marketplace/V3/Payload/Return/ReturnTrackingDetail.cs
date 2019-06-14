namespace Walmart.Sdk.Marketplace.V3.Payload.Return
{
	using System;
	using Newtonsoft.Json;

	public class ReturnTrackingDetail
	{
		[JsonProperty("sequenceNo", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int? SequenceNo { get; set; }

		[JsonProperty("eventTag", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string EventTag { get; set; }

		[JsonProperty("eventDescription", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string EventDescription { get; set; }

		[JsonProperty("eventTime", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public DateTime? EventTime { get; set; }
	}
}
