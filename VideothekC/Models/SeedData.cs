using Microsoft.EntityFrameworkCore;
using VideothekC.HelperToolkit;

namespace VideothekC.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new VideothekDbContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<VideothekDbContext>>());
        if (!context.Database.CanConnect()) context.Database.Migrate();
        if (context == null) throw new ArgumentNullException(nameof(serviceProvider));

        // Look for any movies.
        if (!context.Films.Any())
            context.Films.AddRange(
                new Film("5KZ3MKraNKY", "Halo The Series (2022) | Official Trailer | Paramount+",
                    "Action", 4,
                    "HaloTheSeries #MasterChief #ParamountPlus Dramatizing an epic 26th-century conflict between humanity and an alien threat ...",
                    "https://www.youtube.com/embed/5KZ3MKraNKY",
                    "https://i.ytimg.com/vi/5KZ3MKraNKY/mqdefault.jpg")
                ,
                new Film("9ix7TUGVYIo", "The Matrix Resurrections – Official Trailer 1",
                    "Science fiction", 5,
                    "The Matrix Resurrections in theaters and on HBO Max December 22 #TheMatrixMovie ...",
                    "https://www.youtube.com/embed/9ix7TUGVYIo", "https://i.ytimg.com/vi/9ix7TUGVYIo/mqdefault.jpg")
                ,
                new Film("D09aGdEDK2U",
                    "TERMINATOR 7: End Of War (2022) Official Trailer Teaser - Arnold Schwarzenegger",
                    "Science fiction", 2,
                    "Arnold Schwarzenegger Terminator 7 Name End of war Official Trailer and Teaser coming in 2022. Terminator: 7. An augmented ...",
                    "https://www.youtube.com/embed/D09aGdEDK2U", "https://i.ytimg.com/vi/D09aGdEDK2U/mqdefault.jpg")
                ,
                new Film("JnFQv6hnUuU", "A Day to Die Trailer #1 (2022) | Movieclips Trailers",
                    "Action", 5,
                    "Check out the A Day to Die Official Trailer starring Kevin Dillon and Bruce Willis! Let us know what you think in the comments ...",
                    "https://www.youtube.com/embed/JnFQv6hnUuU", "https://i.ytimg.com/vi/JnFQv6hnUuU/mqdefault.jpg")
                ,
                new Film("oMSdFM12hOw", "THE NORTHMAN - Official Trailer - Only In Theaters April 22",
                    "Action", 3,
                    "From visionary director Robert Eggers comes THE NORTHMAN, an action-filled epic that follows a young Viking prince on his ...",
                    "https://www.youtube.com/embed/oMSdFM12hOw", "https://i.ytimg.com/vi/oMSdFM12hOw/mqdefault.jpg")
            );
        
        if (!context.Customers.Any())
            context.Customers.AddRange(
                new Customer("alain.gomez@cargonerds.com", "1234")
                {
                    FirstName = "Alain",
                    LastName = "Gomez",
                    City = "Hamburg",
                    PostalCode = 20539,
                    Street = "Harbuger 10000",
                    Country = "Germany",
                    Verify = true,
                    Confirmation = RandomService.RandomPassword()
                },
                new Customer("bryan.fatjo@gmail.com", "1234")
                {
                    FirstName = "Bryan",
                    City = "Hamburg",
                    PostalCode = 20539,
                    Street = "Harburger I dont know",
                    Country = "Germany",
                    Verify = true,
                    Confirmation = RandomService.RandomPassword()
                });


        context.SaveChanges();
    }
}