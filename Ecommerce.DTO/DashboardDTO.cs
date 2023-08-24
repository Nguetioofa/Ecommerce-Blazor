using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class DashboardDTO
    {
        public string? TotalRevenus { get; set; }
        public int TotalVente { get; set; }
        public int TotalClient { get; set;}
        public int TotalProduit { get; set; }
    }
}
