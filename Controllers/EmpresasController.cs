using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class EmpresasController : ControllerBase
{
    private readonly IRepository<Empresa> _repository;
    private readonly IEmpresaRepository _empresaRepository;
    private readonly BibliotecaContext _db;

    public EmpresasController(IRepository<Empresa> repository, IEmpresaRepository empresaRepository, BibliotecaContext db)
    {
        _repository = repository;
        _empresaRepository = empresaRepository;
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas()
    {
        var empresas = await _repository.ObtenerTodos();
        return Ok(empresas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Empresa>> GetEmpresa(int id)
    {
        var empresa = await _repository.ObtenerPorId(id);
        if (empresa == null)
        {
            return NotFound();
        }
        return Ok(empresa);
    }

    [HttpPost]
    public async Task<ActionResult<Empresa>> PostEmpresa(Empresa empresa)
    {
        empresa.Empresa_Fecha_Creacion = DateTime.SpecifyKind(empresa.Empresa_Fecha_Creacion, DateTimeKind.Utc);
        var creada = await _repository.Agregar(empresa);
        return Ok(creada);
    }

    [HttpGet("pais/{pais}")]
    public ActionResult<IEnumerable<Empresa>> GetEmpresasPorPais(string pais)
    {
        var empresas = _db.empresa.AsNoTracking().Where(e => e.Empresa_Pais_Origen == pais).ToList();
        return Ok(empresas);
    }

    [HttpGet("/paises_old")]
    public ActionResult<IEnumerable<string>> GetPaisesOld()
    {
        var paises = _db.empresa.AsNoTracking().Select(e => e.Empresa_Pais_Origen).Distinct().ToList();
        return Ok(paises);
    }

    [HttpGet("nombre/{nombre}")]
    public async Task<ActionResult<Empresa>> GetEmpresaPorNombre(string nombre)
    {
        var empresa = await _empresaRepository.ObtenerEmpresaPorNombre(nombre);
        if (empresa == null)
        {
            return NotFound();
        }
        return Ok(empresa);
    }
}
