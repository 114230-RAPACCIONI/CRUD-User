using System.Net;
using AutoMapper;
using PruebaTecnica.Dtos;
using PruebaTecnica.Models;
using PruebaTecnica.Repositories;
using PruebaTecnica.Response;

namespace PruebaTecnica.Services.Impl;

public class UserServiceImpl : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserServiceImpl(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<List<UserDto>>> getAllUsers()
    {
        var response = new ApiResponse<List<UserDto>>();
        var user = await _userRepository.getAllUsers();

        response.Data = _mapper.Map<List<UserDto>>(user);

        return response;

    }

    public async Task<ApiResponse<UserDto>> getUserById(int idUser)
    {
        var response = new ApiResponse<UserDto>();
        var user = await _userRepository.getUserById(idUser);

        if (user != null)
        {
            response.Data = _mapper.Map<UserDto>(user);
            return response;
        }
        else
        {
            response.SetError("Id incorrecto", HttpStatusCode.BadRequest);
            return response;
        }
    }

    public async Task<ApiResponse<UserDto>> createUser(UserDto userDto)
    {
        if (userDto == null)
        {
            return new ApiResponse<UserDto>
            {
                Data = null,
                Message = "El usuario es nulo",
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        User user = _mapper.Map<User>(userDto);
        
        try
        {
            User userResponse = await _userRepository.createUser(user);

            if (userResponse == null)
            {
                var resp = new ApiResponse<UserDto>();
                resp.SetError("Error interno", HttpStatusCode.InternalServerError);
            }

            UserDto userDtoMap = _mapper.Map<UserDto>(userResponse);

            return new ApiResponse<UserDto>
            {
                Data = userDtoMap
            };
        }
        catch (Exception e)
        {
            return new ApiResponse<UserDto>
            {
                Data = null,
                Message = "Error interno",
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
    }

    public async Task<ApiResponse<UserDto>> updateUser(int idUser, UserDto userDto)
    {
        
        if (userDto == null)
        {
            return new ApiResponse<UserDto>
            {
                Data = null,
                Message = "El usuario es nulo",
                StatusCode = HttpStatusCode.BadRequest
            };
        }
        
        User user = _mapper.Map<User>(userDto);

        try
        {
            User userResponse = await _userRepository.updateUser(idUser, user);

            if (userResponse == null)
            {
                var resp = new ApiResponse<UserDto>();
                resp.SetError("Error interno", HttpStatusCode.InternalServerError);
            }

            UserDto userDtoMap = _mapper.Map<UserDto>(userResponse);

            return new ApiResponse<UserDto>
            {
                Data = userDtoMap
            };
        }
        catch (Exception e)
        {
            return new ApiResponse<UserDto>
            {
                Data = null,
                Message = "Error interno",
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
    }

    public async Task<ApiResponse<HttpStatusCode>> deleteUser(int idUser)
    {
        if (idUser <= 0)
        {
            return new ApiResponse<HttpStatusCode>
            {
                Data = HttpStatusCode.NotFound,
                Message = "El ID del usuario debe ser mayor a 0",
            };
        }

        try
        {
            bool result = await _userRepository.deleteUser(idUser);
            
            return new ApiResponse<HttpStatusCode> { Data = HttpStatusCode.OK };
        }
        catch (Exception e)
        {
            return new ApiResponse<HttpStatusCode>
            {
                Data = HttpStatusCode.NotFound,
                Message = e.Message,
            };
        }
    }
}