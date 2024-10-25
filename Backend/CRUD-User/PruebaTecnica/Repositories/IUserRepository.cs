using PruebaTecnica.Models;

namespace PruebaTecnica.Repositories;

public interface IUserRepository
{
    Task<List<User>> getAllUsers();
    Task<User> getUserById(int idUser);
    Task<User> createUser(User user);
    Task<User> updateUser(int idUser, User user);
    Task<bool> deleteUser(int idUser);
}