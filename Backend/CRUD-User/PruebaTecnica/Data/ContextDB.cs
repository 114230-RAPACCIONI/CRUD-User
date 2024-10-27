using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Models;

namespace PruebaTecnica.Data;

/*
 * Clase para crear el contexto a la base de datos.
 */
public class ContextDB : DbContext
{
    public ContextDB(DbContextOptions<ContextDB> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }   
}