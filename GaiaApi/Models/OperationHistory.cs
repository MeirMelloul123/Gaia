using Microsoft.Identity.Client;

namespace GaiaApi.Models
{
    public class OperationHistory
    {
        public int Id { get; set; }
        public string? FirstField { get; set; }
        public int OperationId { get; set; }
        public string? SecondField { get; set; }
        public string? Result { get; set; }
        public DateTime CreateAt { get; set; }
        public Operation? Operation { get; set; }
    }
}
