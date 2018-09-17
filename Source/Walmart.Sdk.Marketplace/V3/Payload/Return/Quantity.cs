﻿

namespace Walmart.Sdk.Marketplace.V3.Payload.Return
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.Text;

	public class Quantity
	{
		[JsonProperty("unitOfMeasure", Required = Newtonsoft.Json.Required.Always)]
		public string UnitOfMeasure { get; set; }

		[JsonProperty("measurementValue", Required = Newtonsoft.Json.Required.Always)]
		public double MeasurementValue { get; set; }
	}
}
