using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PaisesController : ControllerBase
{
    private readonly IRepository<Pais> _repository;
    private readonly IPaisRepository _paisRepository;

    public PaisesController(IRepository<Pais> repository, IPaisRepository paisRepository)
    {
        _repository = repository;
        _paisRepository = paisRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pais>>> GetPaises()
    {
        var paises = await _paisRepository.ObtenerTodos();
        return Ok(paises);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pais>> GetPais(int id)
    {
        var pais = await _repository.ObtenerPorId(id);
        if (pais == null)
        {
            return NotFound();
        }
        return Ok(pais);
    }

    [HttpPost]
    public async Task<ActionResult<Pais>> PostPais(Pais pais)
    {
        var creado = await _repository.Agregar(pais);
        return Ok(creado);
    }

    [HttpGet("nombre/{nombre}")]
    public async Task<ActionResult<Pais>> GetPaisPorNombre(string nombre)
    {
        var pais = await _paisRepository.ObtenerPaisPorNombre(nombre);
        if (pais == null)
        {
            return NotFound();
        }
        return Ok(pais);
    }

    [HttpDelete("id/{id}")]
    public async Task<ActionResult<Pais>> EliminarPais(int id)
    {
        var pais = await _repository.ObtenerPorId(id);
        if (pais != null) await _repository.Eliminar(pais);

        return Ok(pais);
    }
}
