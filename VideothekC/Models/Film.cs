namespace VideothekC.Models;

public class Film
{
    public Film(string id, string filmName, string genre, int duration, string filmDescription, string filmSource,
        string thumbsnails)
    {
        Id = id;
        FilmName = filmName;
        Genre = genre;
        Duration = duration;
        FilmDescription = filmDescription;
        FilmSource = filmSource;
        Thumbsnails = thumbsnails;
    }

    public string Id { get; set; }
    public string FilmName { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; }
    public string FilmDescription { get; set; }
    public string FilmSource { get; set; }
    public string Thumbsnails { get; set; }

    public ICollection<CustomerViewedFilm>? CustomerViewedFilms { get; set; }
}