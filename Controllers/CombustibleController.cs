using ApiCombustibles.AppSettingModels;
using ApiCombustibles.Response;
using ApiCombustibles.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCombustibles.Models;

namespace ApiCombustibles.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CombustibleController : Controller
    {
        private readonly ICombustibleService _combustibleService;

        public CombustibleController(ICombustibleService combustibleService)
        {
            this._combustibleService = combustibleService;
        }
        
        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 5)]
        public async Task<ActionResult<ApiResponse<List<Combustible>>>> Get()
        {
            var response = new ApiResponse<List<Combustible>>();
            try
            {
                response.Combustibles = await this._combustibleService.GetCombustible();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Se produjo un error al obtener los datos\n{ex.Message}";
            }
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
