using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gestpsfe.Models;

public partial class Circuit
{
    public int Id { get; set; }
  
    public string CircuitName { get; set; } = null!;
    public double Km { get; set; }
    public double Cout { get; set; }
    [JsonIgnore]
    public virtual ICollection<Shift>? Shifts { get; set; } = new List<Shift>();
    public virtual ICollection<Station>? Stations { get; set; } = new List<Station>();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Circuit()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}
