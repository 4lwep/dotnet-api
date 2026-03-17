using Microsoft.EntityFrameworkCore;

public class BibliotecaContext : DbContext { 
    public BibliotecaContext(DbContextOptions<BibliotecaContext> options) 
        : base(options)
    {
    } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("biblioteca");

        
    }
    public DbSet<Empresa> empresa { get; set; } 
    public DbSet<Pais> pais { get; set; }
}