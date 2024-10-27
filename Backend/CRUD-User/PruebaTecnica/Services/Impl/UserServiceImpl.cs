using System.Net;
using AutoMapper;
using PruebaTecnica.Dtos;
using PruebaTecnica.Models;
using PruebaTecnica.Repositories;
using PruebaTecnica.Response;

namespace PruebaTecnica.Services.Impl;

/*
 * Implementacion del servicio de usuarios.
 */
public class UserServiceImpl : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserServiceImpl(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    /**
     * Obtiene todos los usuarios y los mapea a DTOs para la respuesta.
     * @return ApiResponse de la lista de UserDto.
     */
    public async Task<ApiResponse<List<UserDto>>> getAllUsers()
    {
        var response = new ApiResponse<List<UserDto>>();
        var user = await _userRepository.getAllUsers();

        response.Data = _mapper.Map<List<UserDto>>(user);

        return response;

    }

    /*
     * Obtiene un usuario por su identificador y lo mapea a su DTO.
     * @param idUser Identificador del usuario.
     * @return ApiResponse con el UserDto, o un error si no se encuentra el resultado.
     */
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

    /*
     * Crea un usuario a partir de su DTO y lo mapea para la respuesta.
     * @param userDto Datos del usuario a crear.
     * @return ApirResponse con UserDto del usuario creado.
     */
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

    /*
     * Actualiza los datos de un usuario existente usuando su identificador.
     * @param idUser Identificador de usuario.
     * @param userUpdateDto Datos del usuario a actualizar.
     * @return ApirResponse con UserUpdateDto del usuario actualizado.
     */
    public async Task<ApiResponse<UserDto>> updateUser(int idUser, UserUpdateDto userUpdateDto)
    {
        
        if (userUpdateDto == null)
        {
            return new ApiResponse<UserDto>
            {
                Data = null,
                Message = "El usuario es nulo",
                StatusCode = HttpStatusCode.BadRequest
            };
        }
        
        User user = _mapper.Map<User>(userUpdateDto);

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

    /*
     * Elimina un usuario de la base de datos usando su identificador.
     * @param idUser Identificador del usuario.
     * @return ApiResponse con el codigo de estado HTTP. 
     */
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