using Microsoft.EntityFrameworkCore;

public interface IPaisRepository
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
}
