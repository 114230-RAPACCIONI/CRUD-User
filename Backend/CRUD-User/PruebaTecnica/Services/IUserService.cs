using System.Net;
using PruebaTecnica.Dtos;
using PruebaTecnica.Response;

namespace PruebaTecnica.Services;

public interface IUserService
{
    /**
     * Obtiene todos los usuarios y los mapea a DTOs para la respuesta.
     */
    Task<ApiResponse<List<UserDto>>> getAllUsers();
    
    /*
     * Obtiene un usuario por su identificador y lo mapea a su DTO.
     */
    Task<ApiResponse<UserDto>> getUserById(int idUser);
    
    /*
     * Crea un usuario a partir de su DTO y lo mapea para la respuesta.
     */
    Task<ApiResponse<UserDto>> createUser(UserDto userDto);
    
    /*
     * Actualiza los datos de un usuario existente usuando su identificador.
     */
    Task<ApiResponse<UserDto>> updateUser(int idUser, UserUpdateDto userUpdateDto);
    
    /*
     * Elimina un usuario de la base de datos usando su identificador.
     */
    Task<ApiResponse<HttpStatusCode>> deleteUser(int idUser);

}