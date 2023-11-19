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
    public class ProduitController : ControllerBase
    {
        private readonly IProduitService _produitService;

        public ProduitController(IProduitService produitService)
        {
            _produitService = produitService;
        }

        [HttpGet("list/{recherche?}")]
        public async Task<IActionResult> List(string recherche = "NA")
        {
            var response = new ReponseDTO<List<ProduitDTO>>();

            try
            {
                if (recherche == "NA") recherche = string.Empty;

                response.EsCorrect = true;
                response.Resultat = await _produitService.List(recherche);
                
            }
            catch (Exception ex)
            {
                response.EsCorrect = false;
                response.Message = ex.Message;
                
            }

            return Ok(response);
        }

        [HttpGet("catalogue/{categorie:alpha}/{chercher:alpha?}")]
        public async Task<IActionResult> Catalogue(string categorie,string recherche = "NA")
        {
            var response = new ReponseDTO<List<ProduitDTO>>();

            try
            {
                if (recherche.ToLower() == "todos") categorie = string.Empty;
                if (recherche == "NA") recherche = string.Empty;

                response.EsCorrect = true;
                response.Resultat = await _produitService.Catalogue(categorie,recherche);

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
            var response = new ReponseDTO<ProduitDTO>();

            try
            {
                response.EsCorrect = true;
                response.Resultat = await _produitService.Get(id);
            }
            catch (Exception ex)
            {
                response.EsCorrect = false;
                response.Message = ex.Message;

            }

            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ProduitDTO model)
        {
            var response = new ReponseDTO<ProduitDTO>();

            try
            {
                response.EsCorrect = true;
                response.Resultat = await _produitService.Add(model);
            }
            catch (Exception ex)
            {
                response.EsCorrect = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }


        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ProduitDTO model)
        {
            var response = new ReponseDTO<bool>();

            try
            {
                response.EsCorrect = true;
                response.Resultat = await _produitService.Update(model);
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
                response.Resultat = await _produitService.Delete(id);
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
