using ApiCombustibles.Models;
using ApiCombustibles.Response;
using ApiCombustibles.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 86400)]
        public async Task<ActionResult<ApiResponse<Combustible>>> Get()
        {
            var response = new ApiResponse<Combustible>();
            try
            {
                response.Data = await this._combustibleService.GetCombustible();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
