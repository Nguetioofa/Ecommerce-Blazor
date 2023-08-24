using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class PanierDTO
    {
        public ProduitDTO? produit { get; set; }
        public int? Quantite { get; set; }
        public decimal? Prix { get; set; }
        public decimal? Total { get; set; }
    }
}
