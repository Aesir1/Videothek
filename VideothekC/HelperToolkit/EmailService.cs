using System.Net;
using System.Net.Mail;

namespace VideothekC.HelperToolkit;

public class EmailService
{
    public static void EmailSender(string email, string subject, string textContent)
    {
        var smtpServerName = "smtp-relay.sendinblue.com";
        var senderEmail = "bryan.fatjo@gmail.com";
        var senderPassword = "J1EZgf370wVxX82a";

        var smtpClient = new SmtpClient
        {
            DeliveryMethod = SmtpDeliveryMethod.Network,
            Host = smtpServerName,
            Port = 587,
            Credentials = new NetworkCredential(senderEmail, senderPassword),
            EnableSsl = true
        };
        try
        {
            Console.WriteLine("email sending");
            smtpClient.Send(senderEmail, email, subject, textContent);
            Console.WriteLine("email sent");
        }
        catch (SmtpException ex)
        {
            Console.WriteLine(ex);
        }
    }
}