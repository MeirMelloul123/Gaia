using GaiaApi.Data;
using GaiaApi.Dto;
using GaiaApi.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GaiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GaiaController : ControllerBase
    {
        private readonly IOperationService _operationService;
        public GaiaController(IOperationService operationService)
        {
            _operationService = operationService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOperationTypes()
        {
            return await _operationService.GetAllOperationTypes() is List<Models.Operation> operationTypes ? Ok(operationTypes) : NotFound();
        }
        [HttpPost]
        [Route("compute")]
        public async Task<IActionResult> Execute([FromBody] CalculationRequest calculationRequest)
        {
            var result = await _operationService.Execute(calculationRequest);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
