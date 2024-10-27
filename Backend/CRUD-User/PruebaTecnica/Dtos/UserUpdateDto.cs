using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Dtos;

/*
 * Clase DTO para actualizar un usuario.
 */
public class UserUpdateDto
{
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