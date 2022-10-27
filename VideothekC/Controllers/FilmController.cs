using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VideothekC.Models;

namespace VideothekC.Controllers;
[EnableCors]
[ApiController]
public class FilmController : Controller
{
    private readonly VideothekDbContext _videothekDbContext;

    public FilmController(VideothekDbContext videothekDbContext)
    {
        _videothekDbContext = videothekDbContext;
    }

    [HttpGet]
    [Route("api/[controller]/films")]
    public ActionResult<IEnumerable<Film>> Films()
    {
        // where to implement my dispose here or on the dependency injection
        var films = _videothekDbContext.Films.ToList();
        if (films.Any()) return films;

        return BadRequest("Ups something went wrong!");
    }

    [HttpGet]
    [Route("api/[controller]/filmsbyid")]
    public ActionResult<Film> FilmsById(string id)
    {
        var film = _videothekDbContext.Films.FirstOrDefault(e => e.Id == id);
        if (film != null) return film;

        return BadRequest($"The film with id:{id} was not found");
    }

    [HttpGet]
    [Route("api/[controller]/filmsbygenre")]
    public ActionResult<IEnumerable<Film>> FilmsByGenre(string genre)
    {
        var films = _videothekDbContext.Films.Where(e => e.Genre == genre).ToList();
        if (films.Any()) return films;

        return BadRequest($"There aren't at the moment any film with this genre: {genre}.");
    }
}