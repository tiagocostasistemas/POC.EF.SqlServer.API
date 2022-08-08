using System.Text.Json.Serialization;

namespace POC.EF.SqlServer.API.DTOs.Address
{
    public class AddressResponse
    {
        [JsonPropertyName("logradouro")]
        public string? Street { get; set; }

        [JsonPropertyName("bairro")]
        public string? District { get; set; }

        [JsonPropertyName("localidade")]
        public string? City { get; set; }

        [JsonPropertyName("uf")]
        public string? State { get; set; }

        [JsonPropertyName("cep")]
        public string? Zipcode { get; set; }
    }
}
