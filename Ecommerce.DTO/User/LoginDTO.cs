using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO.User
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Le L'Email est obligatoire")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Le Mot de passe est obligatoire")]
        public string? MotPasse { get; set; }
    }
}
