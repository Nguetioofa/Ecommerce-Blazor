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
    public class CategorieController : ControllerBase
    {
        private readonly ICategorieService _categorieService;

        public CategorieController(ICategorieService categorieService)
        {
            _categorieService = categorieService;
        }

        [HttpGet("list/{recherche?}")]
        public async Task<IActionResult> List(string recherche = "NA")
        {
            var response = new ReponseDTO<List<CategorieDTO>>();

            try
            {
                if (recherche == "NA") recherche = string.Empty;

                response.EsCorrect = true;
                response.Resultat = await _categorieService.List(recherche);
                
            }
            catch (Exception ex)
            {
                response.EsCorrect = false;
                response.Message = ex.Message;
                
            }

            return Ok(response);
        }

        [HttpGet("get/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = new ReponseDTO<CategorieDTO>();

            try
            {
                response.EsCorrect = true;
                response.Resultat = await _categorieService.Get(id);
            }
            catch (Exception ex)
            {
                response.EsCorrect = false;
                response.Message = ex.Message;

            }

            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CategorieDTO model)
        {
            var response = new ReponseDTO<CategorieDTO>();

            try
            {
                response.EsCorrect = true;
                response.Resultat = await _categorieService.Add(model);
            }
            catch (Exception ex)
            {
                response.EsCorrect = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }


        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] CategorieDTO model)
        {
            var response = new ReponseDTO<bool>();

            try
            {
                response.EsCorrect = true;
                response.Resultat = await _categorieService.Update(model);
            }
            catch (Exception ex)
            {
                response.EsCorrect = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new ReponseDTO<bool>();

            try
            {
                response.EsCorrect = true;
                response.Resultat = await _categorieService.Delete(id);
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
