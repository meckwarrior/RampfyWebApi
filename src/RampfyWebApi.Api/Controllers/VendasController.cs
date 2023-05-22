using Microsoft.AspNetCore.Mvc;
using RampfyWebApi.Application.Authorize;
using RampfyWebApi.Application.HttpModels;
using RampfyWebApi.Application.Interfaces;
using RampfyWebApi.Domain.Entities;

namespace RampfyWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VendasController : ControllerBase
    {
        private readonly IVendaAppService _vendaAppService;

        public VendasController(IVendaAppService vendaAppService)
        {
            _vendaAppService = vendaAppService;
        }

        // GET: api/<VendasController>
        [HttpGet]
        public async Task<IActionResult> GetVendasByDate([FromQuery] VendasRequest request)
        {
            try
            {
                IEnumerable<Venda> vendas = new List<Venda>();

                vendas = await _vendaAppService.GetVendasByDateAsync(request);

                return Ok(vendas);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message ?? e.Message);
            }
        }

        // POST api/<VendasController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IEnumerable<Venda> vendas)
        {
            try
            {
                await _vendaAppService.AddRangeAsync(vendas);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message ?? e.Message);
            }
        }
    }
}
