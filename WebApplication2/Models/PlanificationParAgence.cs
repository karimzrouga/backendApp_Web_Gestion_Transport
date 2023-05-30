using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gestpsfe.Models;

public partial class PlanificationParAgence
{
    public int Id { get; set; }

    public int Nbbus { get; set; }

    public int Capacite { get; set; }
    public int? AgenceId { get; set; }
    [JsonIgnore]
    public virtual Agence ? Agence { get; set; } = null!;
}
