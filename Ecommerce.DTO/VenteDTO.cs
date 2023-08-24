using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class VenteDTO
    {
        public int IdVente { get; set; }
        public int? IdUtilisateur { get; set; }
        public decimal? Total { get; set; }
        public virtual ICollection<DetailVenteDTO> DetailVentes { get; set; } = new List<DetailVenteDTO>();
    }
}
