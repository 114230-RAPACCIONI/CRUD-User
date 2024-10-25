using System.Net;
using PruebaTecnica.Dtos;
using PruebaTecnica.Response;

namespace PruebaTecnica.Services;

public interface IUserService
{
    Task<ApiResponse<List<UserDto>>> getAllUsers();
    Task<ApiResponse<UserDto>> getUserById(int idUser);
    Task<ApiResponse<UserDto>> createUser(UserDto userDto);
    Task<ApiResponse<UserDto>> updateUser(int idUser, UserDto userDto);
    Task<ApiResponse<HttpStatusCode>> deleteUser(int idUser);

}