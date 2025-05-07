using FilmesApi.Data;
using FilmesApi.Entity;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    
    private FilmeContext _context;

    public FilmeController(FilmeContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes([FromQuery] int skip = 0 ,[FromQuery] int take = 50)
    {
        return _context.Filmes.Skip(skip).Take(take);
    }

    [HttpPost]
    public IActionResult AdicionarFilme([FromBody] Filme filme)
    {
        _context.Filmes.Add(filme);
        _context.SaveChanges();
       return CreatedAtAction(nameof(RecuperaFilmePorId), 
           new { id = filme.Id },
           filme);
    }

    [HttpGet("{id}")]
    public Filme? RecuperaFilmePorId(int id)
    {
       return _context.Filmes.FirstOrDefault(filme => filme.Id == id);
    }
}
