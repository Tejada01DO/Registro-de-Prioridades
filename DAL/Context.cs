using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<Prioridades> Prioridades { get; set; }
    public DbSet<Cliente> Clientes { get; set; }

    public Context(DbContextOptions<Context> options) : base(options)
    {
        
    }

}