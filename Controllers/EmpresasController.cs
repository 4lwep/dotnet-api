using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class EmpresasController : ControllerBase
{
    private readonly IEmpresaService _empresaService;

    public EmpresasController(IEmpresaService empresaService)
    {
        _empresaService = empresaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmpresaDTO>>> GetEmpresas()
    {
        var empresas = await _empresaService.ObtenerTodos();
        return Ok(empresas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmpresaDTO>> GetEmpresa(int id)
    {
        var empresa = await _empresaService.ObtenerPorId(id);
        if (empresa == null)
        {
            return NotFound();
        }
        return Ok(empresa);
    }

    [HttpPost]
    public async Task<ActionResult<EmpresaDTO>> PostEmpresa(EmpresaDTO empresa)
    {
        empresa.Empresa_Fecha_Creacion = DateTime.SpecifyKind(empresa.Empresa_Fecha_Creacion, DateTimeKind.Utc);
        var creada = await _empresaService.Agregar(empresa);
        await _empresaService.AgregarEmpresaAPais(empresa);
        return Ok(creada);
    }

    [HttpGet("pais/{pais}")]
    public async Task<ActionResult<IEnumerable<EmpresaDTO>>> GetEmpresasPorPais(string pais)
    {
        var empresas = await _empresaService.ObtenerEmpresasPorPais(pais);
        return Ok(empresas);
    }

    [HttpGet("nombre/{nombre}")]
    public async Task<ActionResult<EmpresaDTO>> GetEmpresaPorNombre(string nombre)
    {
        var empresa = await _empresaService.ObtenerEmpresaPorNombre(nombre);
        if (empresa == null)
        {
            return NotFound();
        }
        return Ok(empresa);
    }

    [HttpDelete("id/{id}")]
    public async Task<ActionResult<EmpresaDTO>> EliminarEmpresa(int id)
    {
        var empresa = await _empresaService.ObtenerPorId(id);
        if (empresa != null) await _empresaService.Eliminar(empresa);

        return Ok(empresa);
    }
}