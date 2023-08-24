using System;
using System.Collections.Generic;

namespace Ecommerce.Modeles;

public partial class Vente
{
    public int IdVente { get; set; }

    public int? IdUtilisateur { get; set; }

    public decimal? Total { get; set; }

    public DateTime? DateCreation { get; set; }

    public virtual ICollection<DetailVente> DetailVentes { get; set; } = new List<DetailVente>();

    public virtual Utilisateur? IdUtilisateurNavigation { get; set; }
}
