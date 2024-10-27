using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica.Models;

namespace PruebaTecnica.Repositories.impl;

/*
 * Implementaicion del repositorio de usuarios.
 */
public class UserRepositoryImpl : IUserRepository
{
    private readonly ContextDB _context;

    public UserRepositoryImpl(ContextDB context)
    {
        _context = context;
    }

    /**
     * Obtiene todos los usuarios dentro de la base de datos.
     * @return Lista de usuarios.
     */
    public async Task<List<User>> getAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    /**
     * Obtiene un usuario por su identificador.
     * @param idUser Identificador del usuairio.
     * @return Usuario si se encuentra, Exception de lo contrario.
     */
    public async Task<User> getUserById(int idUser)
    {
        if (idUser <= 0)
        {
            throw new Exception("El ID de usuario debe ser mayor a 0");
        }
        
        var user = await _context.Users
            .Where(u => u.Id.Equals(idUser))
            .FirstOrDefaultAsync();

        if (user != null)
        {
            return user;
        }

        throw new Exception("Usuario no encontrado en la base de datos");
    }

    /**
     * Crea un nuevo usuario en la base de datos.
     * @param user Objeto User a crear.
     * @return User Objeto creado.
     * @throws Exception si usuario es nulo.
     */
    public async Task<User> createUser(User user)
    {
        if (user == null)
        { 
            throw new Exception("Usuario es nulo");
        }

        if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
        {
            throw new Exception("Todos los campos son requeridos");
        }
        
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    /**
     * Actualiza un usuario en la base de datos.
     * @param idUser Identificador del usuairio.
     * @param user Objeto User a actualizar.
     * @return user Objeto User actualizado.
     * @throws Exception si usuario es nulo.
     */
    public async Task<User> updateUser(int idUser, User user)
    {
        if (idUser <= 0)
        {
            throw new Exception("El ID de usuario debe ser mayor a 0");
        }
        if (user == null)
        { 
            throw new Exception("Usuario es nulo");
        }
        
        var findUser = await _context.Users
            .Where(u => u.Id.Equals(idUser))
            .FirstOrDefaultAsync();
        
        if (findUser == null)
        {
            throw new Exception("El usuario no fue encontrado");
        }

        findUser.Name = user.Name;
        findUser.Email = user.Email;
        findUser.Password = user.Password;

        _context.Users.Update(findUser);
        await _context.SaveChangesAsync();

        return user;

    }

    /**
     * Elimina un usuario en la base de datos.
     * @param idUser Objeto a eliminar.
     * @return true Si se elimino correctamewnte el usuario.
     */
    public async Task<bool> deleteUser(int idUser)
    {
        if (idUser <= 0)
        {
            throw new Exception("El ID de usuario debe ser mayor a 0");
        }
        
        var user = await _context.Users.FindAsync(idUser);

        if (user == null)
        {
            throw new Exception("El usuario no fue encontrado");
        }
        
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return true;
    }
}