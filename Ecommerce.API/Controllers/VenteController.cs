using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.Service.Contrats;
using Ecommerce.Service.Implementations;
using Ecommerce.DTO;
using Ecommerce.Modeles;
using Ecommerce.DTO.User;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenteController : ControllerBase
    {
        private readonly IVenteService _venteService;

        public VenteController(IVenteService venteService)
        {
            _venteService = venteService;
        }

 

        [HttpPost("save")]
        public async Task<IActionResult> Add([FromBody] VenteDTO model)
        {
            var response = new ReponseDTO<VenteDTO>();

            try
            {
                response.EsCorrect = true;
                response.Resultat = await _venteService.Save(model);
            }
            catch (Exception ex)
            {
                response.EsCorrect = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }


 
    }
}
