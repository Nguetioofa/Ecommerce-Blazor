using System;
using System.Collections.Generic;

namespace Ecommerce.Modeles;

public partial class Utilisateur
{
    public int IdUtilisateur { get; set; }

    public string? NomComplet { get; set; }

    public string? Email { get; set; }

    public string? MotPasse { get; set; }

    public string? Role { get; set; }

    public DateTime? DateCreation { get; set; }

    public virtual ICollection<Vente> Ventes { get; set; } = new List<Vente>();
}
