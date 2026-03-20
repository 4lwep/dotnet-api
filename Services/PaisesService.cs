using AutoMapper;

public interface IPaisService : IService<Pais, PaisDTO>
{
    public Task<PaisDTO?> ObtenerPaisPorNombre(string nombre);
}

public class PaisService : Service<Pais, PaisDTO>, IPaisService
{
    private readonly IPaisRepository _paisRepository;

    public PaisService(IPaisRepository paisRepository, IMapper mapper) : base(paisRepository, mapper)
    {
        _paisRepository = paisRepository;
    }

    public async Task<PaisDTO?> ObtenerPaisPorNombre(string nombre)
    {
        var pais = _paisRepository.ObtenerPaisPorNombre(nombre);
        return _mapper.Map<PaisDTO>(pais);
    }


}