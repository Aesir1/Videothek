using VideothekC.HelperToolkit;

namespace VideothekC.Models;

public class Customer : BaseEntity
{
    public Customer(string email, string password)
    {
        Email = email;
        Password = password;
        Verify = false;
        Confirmation = RandomService.RandomPassword();
    }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? Birthday { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public int? PostalCode { get; set; }
    public string? Country { get; set; }
    public bool Verify { get; set; }
    public string Confirmation { get; set; }

    public virtual ICollection<CustomerViewedFilm>? CustomerViewedFilms { get; set; }
}