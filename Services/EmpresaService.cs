using AutoMapper;

public interface IEmpresaService : IService<Empresa, EmpresaDTO>
{
    public Task<EmpresaDTO> ObtenerEmpresaPorNombre(string nombre);

    public Task<IEnumerable<EmpresaDTO>?> ObtenerEmpresasPorPais(string nombrePais);

    public Task<PaisDTO?> ObtenerPaisEmpresa(EmpresaDTO empresa);

    public Task AgregarEmpresaAPais(EmpresaDTO empresa);
}

public class EmpresaService : Service<Empresa, EmpresaDTO>, IEmpresaService
{
    private readonly IEmpresaRepository _empresaRepository;

    public EmpresaService(IEmpresaRepository empresaRepository, IMapper mapper) : base(empresaRepository, mapper)
    {
        _empresaRepository = empresaRepository;
    }

    public async Task<EmpresaDTO> ObtenerEmpresaPorNombre(string nombre)
    {
        var empresa = await _empresaRepository.ObtenerEmpresaPorNombre(nombre);
        return _mapper.Map<EmpresaDTO>(empresa);
    }

    public async Task<IEnumerable<EmpresaDTO>?> ObtenerEmpresasPorPais(string nombrePais)
    {
        var empresas = await _empresaRepository.ObtenerEmpresasPorPais(nombrePais);
        return _mapper.Map<IEnumerable<EmpresaDTO>>(empresas);
    }

    public async Task<PaisDTO?> ObtenerPaisEmpresa(EmpresaDTO empresa)
    {
        var entidad = _mapper.Map<Empresa>(empresa);
        var pais = await _empresaRepository.ObtenerPaisEmpresa(entidad);
        return _mapper.Map<PaisDTO>(pais);
    }

    public async Task AgregarEmpresaAPais(EmpresaDTO empresa)
    {
        var entidad = _mapper.Map<Empresa>(empresa);
        await _empresaRepository.AgregarEmpresaAPais(entidad);
    }
}