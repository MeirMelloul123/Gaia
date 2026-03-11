using GaiaApi.Models;

namespace GaiaApi.Dto
{
    public class CalculationResponse
    {
        public string? Result { get; set; }
        public List<OperationHistoryResponse>? History { get; set; }
        public int Count { get; set; }
    }
}
