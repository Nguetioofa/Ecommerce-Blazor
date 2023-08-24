using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class DetailVenteDTO
    {
        public int IdDetailVente { get; set; }
        public int? IdProduit { get; set; }
        public int? Quantite { get; set; }
        public decimal? Total { get; set; }
    }
}
