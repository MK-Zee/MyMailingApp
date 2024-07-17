using System.Threading.Tasks;

namespace FEProject.Emails
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
