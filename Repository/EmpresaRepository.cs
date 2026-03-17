using Microsoft.EntityFrameworkCore;

public interface IEmpresaRepository
{
    public Task<Empresa?> ObtenerEmpresaPorNombre(string nombre);
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
}