using System.Collections.Generic;
using System.IO;
using System.Xml.Schema;
using Newtonsoft.Json.Schema;

namespace Walmart.Sdk.Base.Util
{
	public class XsdValidation
	{
		public static List<ValidationEventArgs> validateXml(string xsdFilePath, string xmlFilePath)
		{
			// TODO: figure out how to validate xml files with xsd schema
			XmlSchema xsd;
			using (var stream = new FileStream(xsdFilePath, FileMode.Open, FileAccess.Read))
			{
				//xsd = XmlSchema.Read(stream, null);
			}


			return new List<ValidationEventArgs>();
		}
	}
}
