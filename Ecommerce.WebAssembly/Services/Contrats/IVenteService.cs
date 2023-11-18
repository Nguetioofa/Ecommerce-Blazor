using Ecommerce.DTO;


namespace Ecommerce.WebAssembly.Services.Contrats
{
    public interface IVenteService
    {
        Task<ReponseDTO<VenteDTO>> Save(VenteDTO model);

    }
}
