using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gestpsfe.Models;

public partial class Permission
{
    public int Id { get; set; }
   
    public string title { get; set; }

    public string description { get; set; }
    [JsonIgnore]

    public virtual ICollection<User>? Users { get; set; } = new List<User>();

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Permission()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}
