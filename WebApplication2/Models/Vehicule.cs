using System;
using System.Collections.Generic;

namespace Gestpsfe.Models;

public partial class Vehicule
{
    public int Id { get; set; }

    public string Immatricule { get; set; } = null!;

    public int Capacite { get; set; }

    public int AgenceId { get; set; }

    public virtual Agence Agence { get; set; } = null!;

    public virtual ICollection<Station> Stations { get; set; } = null!;
}
