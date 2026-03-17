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

    public async Task<IEnumerable<Empresa>?> ObtenerEmpresasPorPais(string nombrePais)
    {
        return await _db.empresa.AsNoTracking().Where(e => e.Empresa_Pais_Origen == nombrePais).ToListAsync();
    }
}
