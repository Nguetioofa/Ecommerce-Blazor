using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO.User
{
    public class UtilisateurDTO
    {
        public int IdUtilisateur { get; set; }

        [Required(ErrorMessage = "Le Nom est obligatoire")]
        public string? NomComplet { get; set; }

        [Required(ErrorMessage = "Le L'Email est obligatoire")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Le Mot de passe est obligatoire")]
        public string? MotPasse { get; set; }

        [Required(ErrorMessage = "La confirmation du mot de passe est obligatoire")]
        public string? ConfirmerMotPasse { get; set; }

        public string? Role { get; set; }
    }
}
