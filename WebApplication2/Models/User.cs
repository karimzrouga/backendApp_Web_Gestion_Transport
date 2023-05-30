using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gestpsfe.Models;

public partial class User 
{
    public User()
    {
        CreatedDate = DateTime.Now;
    }
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string Mdp { get; set; } = null!;

    public string Matricule { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public int? RoleId { get; set; }
    public virtual Role? Role { get; set; }

    public int? PermissionId { get; set; }
    public virtual Permission? Permission { get; set; }
    public string? Email { get; set; }

    public string? Plansection { get; set; }

    public string? Segment { get; set; }

    public int ListePlanificationId { get; set; }
    [JsonIgnore]
    public virtual ListePlanification? Planification { get; set; }


    public int? ShiftId { get; set; }
    [JsonIgnore]
    public virtual Shift? Shift { get; set; }

public string? Token { get; set; }

    public double Salaire { get; set; }

    public virtual ICollection<Cotisation> ?Cotisations { get; set; } = new List<Cotisation>();





}


