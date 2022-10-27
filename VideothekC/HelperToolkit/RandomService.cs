namespace VideothekC.HelperToolkit;

internal static class RandomService
{
    public static string RandomPassword()
    {
        var randomPassword = "";
        var random = new Random();
        for (var i = 0; i < 16; i++)
        {
            var spring = Convert.ToBoolean(random.Next(2));
            if (spring)
            {
                var character = Convert.ToChar(random.Next(48, 57));
                randomPassword += character;
            }
            else
            {
                var character = Convert.ToChar(random.Next(65, 90));
                randomPassword += character;
            }
        }

        return randomPassword;
    }
}