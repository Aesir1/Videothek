using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VideothekC.HelperToolkit;
using VideothekC.Models;

namespace VideothekC.Controllers;

[EnableCors]
[ApiController]
public class CustomerController : Controller
{
    private readonly VideothekDbContext _videothekDbContext;

    public CustomerController(VideothekDbContext videothekDbContext)
    {
        _videothekDbContext = videothekDbContext;
    }

    [HttpGet]
    [Route("api/[controller]/signIn")]
    public ActionResult<Customer> SignIn(string email, string password)
    {
        var entity = _videothekDbContext.Customers.FirstOrDefault(e => e.Email == email);


        if (entity != null)
        {
            if (entity.Password == password)
                return entity;
            return Unauthorized("Password doesn't match");
        }

        return NotFound("This Email '" + email + "' haven't been registered yet. Please SignUp!");
    }


    [HttpPost]
    [Route("api/[controller]/signUp")]
    public ActionResult SignUp([FromBody] Customer customer)
    {
        var personalConfirmation = RandomService.RandomPassword();
        var confirmLink = "https://localhost:7256/api/customer";
        var subject = "Account confirmation";
        var content =
            $"Hello {customer.FirstName},\nPlease click on the link below to confirm your email address. \n {confirmLink + "?confirmation=" + personalConfirmation}";


        try
        {
            customer.Confirmation = personalConfirmation;
            _videothekDbContext.Customers.Add(customer);
            _videothekDbContext.SaveChanges();

            EmailService.EmailSender(customer.Email, subject, content);
            return Accepted();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpGet]
    [Route("api/[controller]/confirmUser")]
    public ActionResult ConfirmUser(string confirmation)
    {
        var entity = _videothekDbContext.Customers.FirstOrDefault(e => e.Confirmation == confirmation);

        if (entity != null && entity.Verify)
        {
            var done = "The link was already verified!";
            return Ok(done);
        }

        if (entity != null)
        {
            entity.Verify = true;
            _videothekDbContext.SaveChanges();
            return Ok(true);
        }

        return NotFound("The confirmation link isn't valid! Please contact the customer service!");
    }


    [HttpPatch]
    [Route("api/[controller]/password")]
    public ActionResult Password(string email)
    {
        // Variables for Email
        var newPassword = RandomService.RandomPassword();
        var subject = "Password reset";

        {
            var customer = _videothekDbContext.Customers.FirstOrDefault(e => e.Email == email);
            if (customer != null)
            {
                customer.Password = newPassword;
                _videothekDbContext.SaveChanges();

                var content = $"Hello {customer.FirstName},\nYour new password is {newPassword} \nTry it again!";
                // how to catch the exception
                EmailService.EmailSender(customer.Email, subject, content);
                return Accepted();
            }

            return NotFound($"These '{email}' hasnt been registered yet. Please sign up or check your email!");
        }
    }
}