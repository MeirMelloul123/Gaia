using GaiaApi.Dto;
using GaiaApi.Models;

namespace GaiaApi.Interface
{
    public interface IOperationService
    {
        Task<List<Operation>?> GetAllOperationTypes();
        Task<CalculationResponse?> Execute(CalculationRequest calculationRequest);
    }
}
