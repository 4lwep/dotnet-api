using Microsoft.EntityFrameworkCore;

public interface IPaisRepository : IRepository<Pais>
{
    public Task<Pais?> ObtenerPaisPorNombre(string nombre);
}

public class PaisRepository : Repository<Pais>, IPaisRepository
{
    public PaisRepository(BibliotecaContext db) : base(db)
    {
    }

    public async Task<Pais?> ObtenerPaisPorNombre(string nombre)
    {
        return await _db.pais.FirstOrDefaultAsync(p => p.Pais_Nombre == nombre);
    }

    public override async Task<IEnumerable<Pais>> ObtenerTodos()
    {
        return await _db.pais.Include(p => p.Pais_Empresas).ToListAsync();
    }
}
