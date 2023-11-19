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
    public class UtilisateurController : ControllerBase
    {
        private readonly IUtilisateurService _utilisateurService;

        public UtilisateurController(IUtilisateurService utilisateurService)
        {
                _utilisateurService = utilisateurService;
        }

        [HttpGet("list/{role:alpha}/{recherche?}")]
        public async Task<IActionResult> List(string role,string recherche = "NA")
        {
            var response = new ReponseDTO<List<UtilisateurDTO>>();

            try
            {
                if (recherche == "NA") recherche = string.Empty;

                response.EsCorrect = true;
                response.Resultat = await _utilisateurService.List(role, recherche);
                
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
            var response = new ReponseDTO<UtilisateurDTO>();

            try
            {
                response.EsCorrect = true;
                response.Resultat = await _utilisateurService.Get(id);
            }
            catch (Exception ex)
            {
                response.EsCorrect = false;
                response.Message = ex.Message;

            }

            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody]UtilisateurDTO model)
        {
            var response = new ReponseDTO<UtilisateurDTO>();

            try
            {
                response.EsCorrect = true;
                response.Resultat = await _utilisateurService.Add(model);
            }
            catch (Exception ex)
            {
                response.EsCorrect = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("authentification")]
        public async Task<IActionResult> Authentification([FromBody] LoginDTO model)
        {
            var response = new ReponseDTO<SessionDTO>();

            try
            {
                response.EsCorrect = true;
                response.Resultat = await _utilisateurService.Autorization(model);
            }
            catch (Exception ex)
            {
                response.EsCorrect = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UtilisateurDTO model)
        {
            var response = new ReponseDTO<bool>();

            try
            {
                response.EsCorrect = true;
                response.Resultat = await _utilisateurService.Update(model);
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
                response.Resultat = await _utilisateurService.Delete(id);
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
