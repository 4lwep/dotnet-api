using Microsoft.EntityFrameworkCore;

public interface IEmpresaRepository : IRepository<Empresa>
{
    public Task<Empresa?> ObtenerEmpresaPorNombre(string nombre);

    public Task<IEnumerable<Empresa>?> ObtenerEmpresasPorPais(string nombrePais);

    public Task<Pais?> ObtenerPaisEmpresa(Empresa empresa);

    public Task AgregarEmpresaAPais(Empresa empresa);
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

    public async Task<Pais?> ObtenerPaisEmpresa(Empresa empresa)
    {
        return await _db.pais.FirstOrDefaultAsync(u => u.Pais_Id == empresa.Pais_Id);
    }

    public async Task AgregarEmpresaAPais(Empresa empresa)
    {
        var pais = await ObtenerPaisEmpresa(empresa);
        pais?.Pais_Empresas?.Add(empresa);
        await _db.SaveChangesAsync();
    }
}