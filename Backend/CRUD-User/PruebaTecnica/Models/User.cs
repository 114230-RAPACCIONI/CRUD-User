using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Models;

[Table("users")]
public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    
}