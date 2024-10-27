using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Models;

/*
 * Clase que represnta el Modelo de usuario.
 */

[Table("users")]
public class User
{
    /*
     * Identificador del usuario.
     */
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    /*
     * Nombre del usuario.
     */
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string Name { get; set; } = null!;
    
    /*
     * Email del usuario.
     */
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [EmailAddress(ErrorMessage = "El formato de Email es invalido")]
    public string Email { get; set; } = null!;
    
    /*
     * Contraseña del usuario.
     */
    public string Password { get; set; } = null!;
    
}