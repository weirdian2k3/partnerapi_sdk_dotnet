namespace Walmart.Sdk.Marketplace.V3.Payload.Token
{
	using System.Xml;
	using System.Xml.Serialization;
	using Walmart.Sdk.Base.Primitive;

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "4.4.0.7")]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlRootAttribute("OAuthTokenDTO", IsNullable = false)]
	public class TokenFeedResponse : BasePayload
	{
		[XmlElement("accessToken")]
		public string AccessToken { get; set; }

		[XmlElement("tokenType")]
		public string TokenType { get; set; }

		[XmlElement("expiresIn")]
		public int ExpiresIn { get; set; }
	}
}