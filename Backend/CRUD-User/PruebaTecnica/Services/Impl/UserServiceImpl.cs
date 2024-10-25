using System.Net;
using AutoMapper;
using PruebaTecnica.Dtos;
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
            throw new Exception("El usuario es nulo");
        }

        Models.User user = _mapper.Map<Models.User>(userDto);
        Models.User userResponse = await _userRepository.createUser(user);

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

    public async Task<ApiResponse<UserDto>> updateUser(int idUser, UserDto userDto)
    {
        if (userDto == null)
        {
            throw new Exception("El usuario es nulo");
        }
        
        Models.User user = _mapper.Map<Models.User>(userDto);

        Models.User userResponse = await _userRepository.updateUser(idUser, user);

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

    public async Task<ApiResponse<HttpStatusCode>> deleteUser(int idUser)
    {
        bool result = await _userRepository.deleteUser(idUser);

        if (result)
        {
            return new ApiResponse<HttpStatusCode> { Data = HttpStatusCode.OK };
        }
        else {
            throw new Exception("El usuario no fue encontrado");
        }
    }
}