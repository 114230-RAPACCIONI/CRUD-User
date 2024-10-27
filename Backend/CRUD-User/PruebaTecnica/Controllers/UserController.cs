using System.Net;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Dtos;
using PruebaTecnica.Response;
using PruebaTecnica.Services;

namespace PruebaTecnica.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    /*
     * Endpoint para obtener todos los usuarios.
     * @return Lista de todos los usuarios.
     */
    [HttpGet("/users/getAllUser")]
    public Task<ApiResponse<List<UserDto>>> getAllUsers()
    {
        return _userService.getAllUsers();
    }
    
    /*
     * Endpoint para obtener un usuario por su ID.
     * @param idUser Identificador del usuario.
     * @return User encontrado.
     */
    [HttpGet("/users/getUserById/{idUser}")]
    public Task<ApiResponse<UserDto>> getUserById(int idUser)
    {
        return _userService.getUserById(idUser);
    }
    
    /*
     * Endpoint para crear un nuevo usuario.
     * @param userDto DTO del usuario a crear.
     * @return User creado.
     */
    [HttpPost("/users/createUser")]
    public Task<ApiResponse<UserDto>> createUser([FromBody] UserDto userDto)
    {
        return _userService.createUser(userDto);
    }
    
    /*
     * Endpoint para actualizar un nuevo usuario usuando su identificador.
     * @param idUser Identificador del usuario.
     * @param userUpdateDto DTO con los datos del usuario a actualizar.
     * @return UserUpdateDto actualizado.
     */
    [HttpPut("/users/updateUser/{idUser}")]
    public Task<ApiResponse<UserDto>> updateUser(int idUser, [FromBody] UserUpdateDto userUpdateDto)
    {
        return _userService.updateUser(idUser, userUpdateDto);
    }
    
    /*
     * Endpoint para eliminar un usuario.
     * @param idUser Identificador del usuario.
     * @return Codigo de estado HTTP. 
     */
    [HttpDelete("/users/deleteUser/{idUser}")]
    public Task<ApiResponse<HttpStatusCode>> deleteUser(int idUser)
    {
        return _userService.deleteUser(idUser);
    }
}

