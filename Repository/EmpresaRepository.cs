using Microsoft.EntityFrameworkCore;

public interface IEmpresaRepository : IRepository<Empresa>
{
    public Task<Empresa?> ObtenerEmpresaPorNombre(string nombre);

    public Task<IEnumerable<Empresa>?> ObtenerEmpresasPorPais(string nombrePais);
}

public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
{
    public EmpresaRepository(BibliotecaContext db) : base(db)
    {
    }

    public async Task<Empresa?> ObtenerEmpresaPorNombre(string nombre)
    {
        return await _db.empresa.FirstOrDefaultAsync(e => e.Empresa_Nombre == nombre);
    }

    public async Task<IEnumerable<Empresa>?> ObtenerEmpresasPorPais(string nombrePais)
    {
        return await _db.empresa.AsNoTracking().Where(e => e.Empresa_Pais_Origen == nombrePais).ToListAsync();
    }

    public override async Task<IEnumerable<Empresa>> ObtenerTodos()
    {
        return await _db.empresa.Include(e => e.Empresa_Pais).ToListAsync();
    }
}