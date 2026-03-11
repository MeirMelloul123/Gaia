using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GaiaApi.Models
{
    public class Operation
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public string? Formula { get; set; }
    }
}
