using PruebaTecnica.Models;

namespace PruebaTecnica.Repositories;

public interface IUserRepository
{
    /**
     * Obtiene todos los usuarios dentro de la base de datos.
     */
    Task<List<User>> getAllUsers();
    
    /**
     * Obtiene un usuario por su identificador.
     */
    Task<User> getUserById(int idUser);
    
    /**
    * Crea un nuevo usuario en la base de datos.
    */
    Task<User> createUser(User user);
    
    /**
     * Actualiza un usuario en la base de datos.
     */
    Task<User> updateUser(int idUser, User user);
    
    /**
     * Elimina un usuario en la base de datos.
     */
    Task<bool> deleteUser(int idUser);
}