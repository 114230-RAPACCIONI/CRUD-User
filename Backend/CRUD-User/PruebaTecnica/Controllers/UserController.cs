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
    
    [HttpGet("/users/getAllUser")]
    public Task<ApiResponse<List<UserDto>>> getAllUsers()
    {
        return _userService.getAllUsers();
    }
    
    [HttpGet("/users/getUserById/{idUser}")]
    public Task<ApiResponse<UserDto>> getUserById(int idUser)
    {
        return _userService.getUserById(idUser);
    }
    
    [HttpPost("/users/createUser")]
    public Task<ApiResponse<UserDto>> createUser([FromBody] UserDto userDto)
    {
        return _userService.createUser(userDto);
    }
    
    [HttpPut("/users/updateUser/{idUser}")]
    public Task<ApiResponse<UserDto>> updateUser(int idUser, [FromBody] UserDto userDto)
    {
        return _userService.updateUser(idUser, userDto);
    }
    
    [HttpDelete("/users/deleteUser/{idUser}")]
    public Task<ApiResponse<HttpStatusCode>> deleteUser(int idUser)
    {
        return _userService.deleteUser(idUser);
    }
}

