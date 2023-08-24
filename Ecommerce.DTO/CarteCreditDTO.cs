using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class CarteCreditDTO
    {
        [Required(ErrorMessage = "Le Nom du Proprietaire est obligatoire")]
        public string? Proprietaire { get; set; }
        [Required(ErrorMessage = "Le Numero est obligatoire")]
        [DataType(DataType.CreditCard)]
        public string? Numero { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La Validite est obligatoire")]
        public string? Validite { get; set; }
        [Required(ErrorMessage = "Le CVV est obligatoire")]
        public string? CVV { get; set; }
    }
}
