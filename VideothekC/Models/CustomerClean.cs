namespace VideothekC.Models;

public class CustomerClean : BaseEntity
{
    public CustomerClean(string firstName, string lastName, DateTime birthday, string email, bool verify,
        string street, string city, int postalCode, string country)
    {
        FirstName = firstName;
        LastName = lastName;
        Birthday = birthday;
        Email = email;
        Verify = verify;
        Street = street;
        City = city;
        PostalCode = postalCode;
        Country = country;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public int? PostalCode { get; set; }
    public string? Country { get; set; }
    public bool Verify { get; set; }
}