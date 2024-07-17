using FEProject.Emails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FEProject.Controllers
{
    [ApiController]
    [Route("api/email")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<EmailController> _logger;

        public EmailController(IEmailService emailService, ILogger<EmailController> logger)
        {
            _emailService = emailService;
            _logger = logger;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] EmailSendingDto emailDto)
        {
            if (emailDto == null || string.IsNullOrWhiteSpace(emailDto.ToEmail))
            {
                _logger.LogWarning("Invalid email request.");
                return BadRequest("Invalid email request.");
            }

            try
            {
                await _emailService.SendEmailAsync(emailDto.ToEmail, emailDto.Subject, emailDto.Body);
                _logger.LogInformation("Email sent successfully to: {ToEmail}, Subject: {Subject}", emailDto.ToEmail, emailDto.Subject);
                return Ok("Email sent successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email.");
                return StatusCode(500, "Error sending email.");
            }
        }
    }
}
