// "T" es el tipo de objeto con el que vamos a trabajar (Empresa, Usuario, etc.)
using Microsoft.EntityFrameworkCore;

public interface IRepository<T> where T : class
{
    // Devuelve una lista de "T" (una lista de lo que sea que elijamos)
    Task<IEnumerable<T>> ObtenerTodos();

    // Devuelve un solo objeto de tipo "T" buscado por su ID
    Task<T?> ObtenerPorId(int id);

    // Recibe un objeto de tipo "T" para guardarlo
    Task<T> Agregar(T entidad);
}

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly BibliotecaContext _db;

    public Repository(BibliotecaContext db)
    {
        _db = db;
    }
    public async Task<IEnumerable<T>> ObtenerTodos()
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
}