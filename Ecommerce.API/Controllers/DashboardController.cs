using Ecommerce.DTO;
using Ecommerce.Service.Contrats;
using Ecommerce.Service.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("resume")]
        public IActionResult Resume()
        {
            var response = new ReponseDTO<DashboardDTO>();

            try
            {
                response.EsCorrect = true;
                response.Resultat =  _dashboardService.Resume();
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
