
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Gestpsfe.Models;

public partial class User 
{
 
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    [Required]
    [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Invalid name format. Only alphabets and spaces are allowed.")]
    public string Nom { get; set; } = null!;

    [Required]
    [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Invalid email format.")]
    public string? Email { get; set; }
    public string? adresse { get; set; }
    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Invalid password format. It must contain at least 8 characters, one uppercase letter, one lowercase letter, one number, and one special character.")]
    public string? password { get; set; }
    [JsonIgnore]
    public byte[] ? PasswordHash { get; set; }
    [JsonIgnore]
    public byte[] ? PasswordSalt { get; set; }
    [JsonIgnore]
    public string RefreshToken { get; set; } = string.Empty;
  
    [Required]
    public string Matricule { get; set; } = null!;
    public int? StationId { get; set; }
    public virtual Station? Station { get; set; }
    [Required]
    public int? RoleId { get; set; }
    public virtual Role? Role { get; set; }
    [Required]
    public int? PermissionId { get; set; }
    public virtual Permission? Permission { get; set; }


    public string? Plansection { get; set; }

    public string? Segment { get; set; }

    public int ListePlanificationId { get; set; }
    [JsonIgnore]
    public virtual ListePlanification? Planification { get; set; }


    public int? ShiftId { get; set; }
    [JsonIgnore]
    public virtual Shift? Shift { get; set; }

    public double Salaire { get; set; }
    [JsonIgnore]
    public virtual ICollection<Cotisation> ?Cotisations { get; set; } = new List<Cotisation>();
    public DateTime TokenCreated { get; set; }
    public DateTime TokenExpires { get; set; }
    public User()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }



}


