using System.Text.Json.Serialization;

namespace GaiaApi.Dto
{
    public class CalculationRequest
    {
        [JsonPropertyName("firstField")]
        public string? FisrtField { get; set; }
        [JsonPropertyName("secondField")]
        public string? SecondField { get; set; }
        [JsonPropertyName("operationId")]
        public int OperationId { get; set; }
    }
}
