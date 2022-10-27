namespace VideothekC.Models;

public class CustomerViewedFilm : BaseEntity
{
    public CustomerViewedFilm(DateTime viewedDate, string filmId, Guid customerId)
    {
        ViewedDate = viewedDate;
        FilmId = filmId;
        CustomerId = customerId;
    }

    public DateTime ViewedDate { get; set; }
    public string FilmId { get; set; }
    public Guid CustomerId { get; set; }

    public virtual Film? Film { get; set; }
    public virtual Customer? Customers { get; set; }
}