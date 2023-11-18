using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Contrats
{
    public interface ICategorieService
    {
        Task<ReponseDTO<List<CategorieDTO>>> List(string chercher);
        Task<ReponseDTO<CategorieDTO>> Get(int id);
        Task<ReponseDTO<CategorieDTO>> Add(CategorieDTO model);
        Task<ReponseDTO<bool>> Update(CategorieDTO model);
        Task<ReponseDTO<bool>> Delete(int id);
    }
}
