using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gestpsfe.Models;

public partial class Role
{
  
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public string Description { get; set; } = null!;
  
    public virtual ICollection<User> ? Users  { get; set; }
}
