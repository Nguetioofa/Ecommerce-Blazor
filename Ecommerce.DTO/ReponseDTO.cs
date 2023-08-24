using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class ReponseDTO<T>
    {
        public T? Resultat { get; set; }
        public bool EsCorrect { get; set; }
        public string? Message { get; set; }
    }
}
