using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class ProduitDTO
    {
        public int IdProduct { get; set; }

        [Required(ErrorMessage = "Le Nom du produit est obligatoire")]
        public string? Nom { get; set; }

        [Required(ErrorMessage = "La description est obligatoire")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "L'id de la categorie est obligatoire")]
        public int? IdCategorie { get; set; }

        [Required(ErrorMessage = "Le prix est obligatoire")]
        public decimal? Prix { get; set; }

        [Required(ErrorMessage = "Le prix de l'offre est categorie est obligatoire")]
        public decimal? PrixOffre { get; set; }

        [Required(ErrorMessage = "La quantite est obligatoire")]
        public int? Quantite { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateCreation { get; set; }

        public string? Image { get; set; }

        public virtual CategorieDTO? IdCategorieNavigation { get; set; }
    }
}
