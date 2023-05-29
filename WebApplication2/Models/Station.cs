using System;
using System.Collections.Generic;

namespace Gestpsfe.Models;

public partial class Station
{
    public int Id { get; set; }

    public string Lieu { get; set; } = null!;

    public virtual ICollection<Circuit> Circuits { get; set; } =  null!;

    public virtual ICollection<Vehicule> Vehicules { get; set; } = null!;
}
