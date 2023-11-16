using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO.User
{
    public class SessionDTO
    {
        public int IdUtilisateur { get; set; }
        public string? NomComplet { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
    }
}
