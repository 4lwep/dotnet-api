using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PaisesController : ControllerBase
{
    private readonly IPaisService _paisService;

    public PaisesController(IPaisService paisService)
    {
        _paisService = paisService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PaisDTO>>> GetPaises()
    {
        var paises = await _paisService.ObtenerTodos();
        return Ok(paises);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PaisDTO>> GetPais(int id)
    {
        var pais = await _paisService.ObtenerPorId(id);
        if (pais == null)
        {
            return NotFound();
        }
        return Ok(pais);
    }

    [HttpPost]
    public async Task<ActionResult<PaisDTO>> PostPais(PaisDTO pais)
    {
        var creado = await _paisService.Agregar(pais);
        return Ok(creado);
    }

    [HttpGet("nombre/{nombre}")]
    public async Task<ActionResult<PaisDTO>> GetPaisPorNombre(string nombre)
    {
        var pais = await _paisService.ObtenerPaisPorNombre(nombre);
        if (pais == null)
        {
            return NotFound();
        }
        return Ok(pais);
    }

    [HttpDelete("id/{id}")]
    public async Task<ActionResult<PaisDTO>> EliminarPais(int id)
    {
        var pais = await _paisService.ObtenerPorId(id);
        if (pais != null) await _paisService.Eliminar(pais);

        return Ok(pais);
    }
}
