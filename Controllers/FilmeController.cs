using FilmesApi.Entity;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes([FromQuery] int skip = 0 ,[FromQuery] int take = 50)
    {
        return filmes.Skip(skip).Take(take);
    }

    [HttpPost]
    public IActionResult AdicionarFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
       return CreatedAtAction(nameof(RecuperaFilmePorId), 
           new { id = filme.Id },
           filme);
    }

    [HttpGet("{id}")]
    public Filme? RecuperaFilmePorId(int id)
    {
       return filmes.FirstOrDefault(filme => filme.Id == id);
    }
}
