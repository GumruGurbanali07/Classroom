using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Application.Services;

namespace ToDoList.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MailController : ControllerBase
	{
		private readonly IMailService _mailService;

		public MailController(IMailService mailService)
		{
			_mailService = mailService;
		}

		[HttpPost("send-test-email")]
		public async Task<IActionResult> SendTestEmail()
		{
			try
			{
				string to = "qurbaneliyevaqumru@gmail.com"; // Test email ünvanı
				string subject = "Test E-mail";
				string body = "Bu bir test e-poçtudur. Zəhmət olmasa təsdiqləyin.";

				await _mailService.SendMailAsync(to, subject, body);
				return Ok("Test email sent successfully.");
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "Error sending email: " + ex.Message });
			}
		}
	}
}
