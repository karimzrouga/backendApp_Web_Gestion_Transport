
using System;
using System.Collections.Generic;

namespace Gestpsfe.Models;

public partial class Agence
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string RaisonSocial { get; set; } = null!;

    public string Matricule { get; set; } = null!;

    public virtual ICollection<Facturation> Facturations { get; set; } = null!;
    public virtual ICollection<Vehicule> Vehicules { get; set; } = null!;

    public virtual ICollection<PlanificationParAgence> Planifications { get; set; } = null!;
}
