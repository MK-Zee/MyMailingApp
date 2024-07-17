using FEProject.Emails;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FEProject.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly EmailSettings _emailSettings;

        public EmailService(ILogger<EmailService> logger, IOptions<EmailSettings> emailSettings)
        {
            _logger = logger;
            _emailSettings = emailSettings.Value;

        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            _logger.LogInformation("Sending email to: {ToEmail}, Subject: {Subject}", toEmail, subject);

            try
            {
                var sender = _emailSettings.SenderEmail;
                int port = _emailSettings.SmtpPort;
                // Create a new MailMessage object
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(sender),
                    Subject = subject,
                    Body = body
                };
                mail.To.Add(toEmail);

                // Configure the SmtpClient

                SmtpClient smtpClient = new SmtpClient(_emailSettings.SmtpServer, port)
                {
                    Credentials = new NetworkCredential(_emailSettings.SenderName, _emailSettings.SenderPassword),
                    EnableSsl = true, // Set to true if your SMTP server requires SSL

                };

                // Send the email
                smtpClient.SendMailAsync(mail);
                Console.WriteLine("Email sent successfully!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Email address format is invalid: " + ex.Message);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine("SMTP error: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("A required parameter is null: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                if (ex.InnerException != null)
                {
                    //Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                    _logger.LogError("Inner Exception: " + ex.InnerException.Message);
                }
                //Console.WriteLine("Stack Trace: " + ex.StackTrace);
                _logger.LogError("Stack Trace: " + ex.StackTrace);
            }
        }
    }
}
