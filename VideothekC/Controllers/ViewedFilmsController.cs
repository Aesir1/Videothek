using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VideothekC.Models;

namespace VideothekC.Controllers;
[EnableCors]
[ApiController]
public class ViewedFilmsController : Controller
{
    private readonly VideothekDbContext _videothekDbContext;

    public ViewedFilmsController(VideothekDbContext videothekDbContext)
    {
        _videothekDbContext = videothekDbContext;
    }

    [HttpPost]
    [Route("api/[controller]/setViewedFilm")]
    public ActionResult SetViewedFilm(Guid userId, string filmId)
    {
        var viewedFilmFromDb =
            _videothekDbContext.CustomerViewedFilms.Where(user => user.CustomerId == userId).ToList();
        if (viewedFilmFromDb.Exists(film => film.FilmId == filmId)) return Ok();

        var viewedFilm = new CustomerViewedFilm(DateTime.Now, filmId, userId);
        _videothekDbContext.CustomerViewedFilms.Add(viewedFilm);
        _videothekDbContext.SaveChanges();

        return Accepted();
    }

    [HttpGet]
    [Route("api/[controller]/GetViewedFilms")]
    public ActionResult<IEnumerable<string>> GetViewedFilms(Guid userId)
    {
        var userFilms = new List<Film?>();

        var viewedFilms = _videothekDbContext.CustomerViewedFilms.Where(user => user.CustomerId == userId).ToList();
        var allFilmsFromDb = _videothekDbContext.Films.ToList();
        foreach (var viewedFilm in viewedFilms)
            userFilms.Add(allFilmsFromDb.Find(film => film.Id == viewedFilm.FilmId));


        var justNames = new List<string>();
        if (userFilms.Any())
        {
            foreach (var userFilm in userFilms)
                if (userFilm?.FilmName != null)
                    justNames.Add(userFilm.FilmName);

            return Ok(justNames);
        }


        return Accepted();
    }
}