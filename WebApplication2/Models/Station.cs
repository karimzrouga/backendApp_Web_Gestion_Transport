﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gestpsfe.Models;

public partial class Station
{
    public int Id { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Lieu { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Circuit> ? Circuits { get; set; } = new List<Circuit>();
    [JsonIgnore]
    public virtual ICollection<Vehicule> ?Vehicules { get; set; } = new List<Vehicule>();
    [JsonIgnore]
    public virtual ICollection<User>? Users { get; set; } = new List<User>();
    public override bool Equals(object obj)
    {
        var item = obj as Station;

        if (item == null)
        {
            return false;
        }

        return this.Id == item.Id;
    }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Station()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

}
