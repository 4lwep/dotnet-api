using Microsoft.EntityFrameworkCore;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> ObtenerTodos();

    Task<T?> ObtenerPorId(int id);

    Task<T> Agregar(T entidad);

    Task<T> Eliminar(T entidad);
}

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly BibliotecaContext _db;

    public Repository(BibliotecaContext db)
    {
        _db = db;
    }
    public virtual async Task<IEnumerable<T>> ObtenerTodos()
    {
        return await _db.Set<T>().ToListAsync();
    }

    public async Task<T?> ObtenerPorId(int id)
    {
        return await _db.Set<T>().FindAsync(id);
    }

    public async Task<T> Agregar(T entidad)
    {
        await _db.Set<T>().AddAsync(entidad);

        await _db.SaveChangesAsync();

        return entidad;
    }

    public async Task<T> Eliminar(T entidad)
    {
        _db.Set<T>().Remove(entidad);
        await _db.SaveChangesAsync();

        return entidad;
    }
}