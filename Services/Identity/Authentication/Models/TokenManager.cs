using System;
using System.Text.Json.Serialization;

namespace Identity.JWTAuth
{
	public class TokenManager
	{
        [JsonPropertyName("secret")]
        public string Secret { get; set; }

        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        [JsonPropertyName("audience")]
        public string Audience { get; set; }

        [JsonPropertyName("accessExpiration")]
        public int AccessExpiration { get; set; }

        [JsonPropertyName("refreshExpiration")]
        public int RefreshExpiration { get; set; }

        [JsonPropertyName("secretRefresh")]
        public string SecretRefresh { get; set; }
	}
}

