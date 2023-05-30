using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gestpsfe.Models;

public partial class Circuit
{
    public int Id { get; set; }

    public string CircuitName { get; set; } = null!;

    public double Cout { get; set; }
   
    public virtual ICollection<Station>? Stations { get; set; } = new List<Station>();
}
