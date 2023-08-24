using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class CategorieDTO
    {
        public int IdCategorie { get; set; }
        [Required(ErrorMessage = "Le Nom de la categorie est obligatoire")]
        public string? Nom { get; set; }
    }
}
