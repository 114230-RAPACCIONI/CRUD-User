using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica.Models;

namespace PruebaTecnica.Repositories.impl;

public class UserRepositoryImpl : IUserRepository
{
    private readonly ContextDB _context;

    public UserRepositoryImpl(ContextDB context)
    {
        _context = context;
    }

    public async Task<List<User>> getAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> getUserById(int idUser)
    {
        var user = await _context.Users
            .Where(u => u.Id.Equals(idUser))
            .FirstOrDefaultAsync();

        if (user != null)
        {
            return user;
        }

        throw new Exception("Usuario no encontrado en la base de datos");
    }

    public async Task<User> createUser(User user)
    {
        if (user == null)
        { 
            throw new Exception("Usuario es nulo");
        }

        await _context.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User> updateUser(int idUser, User user)
    {
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

    public async Task<bool> deleteUser(int idUser)
    {
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