using AutoMapper;

public interface IService<T, TDto> 
    where T : class
    where TDto : class
{
    Task<IEnumerable<TDto>> ObtenerTodos();

    Task<TDto?> ObtenerPorId(int id);

    Task<TDto> Agregar(TDto entidad);

    Task<TDto> Eliminar(TDto entidad);
}

public class Service<T, TDto> : IService<T, TDto> where T : class where TDto : class
{
    private readonly IRepository<T> _repository;
    protected readonly IMapper _mapper;

    public Service(IRepository<T> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public virtual async Task<IEnumerable<TDto>> ObtenerTodos()
    {
        var todos = await _repository.ObtenerTodos();
        return _mapper.Map<IEnumerable<TDto>>(todos);
    }

    public async Task<TDto?> ObtenerPorId(int id)
    {
        var entidad = await _repository.ObtenerPorId(id);
        return _mapper.Map<TDto>(entidad);
    }

    public async Task<TDto> Agregar(TDto entidad)
    {
        var nuevo = _mapper.Map<T>(entidad);
        var accion = await _repository.Agregar(nuevo);
        return _mapper.Map<TDto>(accion);
    }

    public async Task<TDto> Eliminar(TDto entidad)
    {
        var eliminado = _mapper.Map<T>(entidad);
        var accion = await _repository.Eliminar(eliminado);
        return _mapper.Map<TDto>(accion); 
    }
}