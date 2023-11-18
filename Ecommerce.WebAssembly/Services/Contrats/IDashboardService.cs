using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Contrats
{
    public interface IDashboardService
    {
       Task<ReponseDTO<DashboardDTO>> Resume();

    }
}
