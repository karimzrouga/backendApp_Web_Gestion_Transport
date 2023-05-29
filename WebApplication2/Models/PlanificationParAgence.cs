using System;
using System.Collections.Generic;

namespace Gestpsfe.Models;

public partial class PlanificationParAgence
{
    public int Id { get; set; }

    public int Nbbus { get; set; }

    public int Capacite { get; set; }

    public virtual ICollection<Agence> Agences { get; set; } = null!;
}
