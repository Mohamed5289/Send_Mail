using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendEmail.DTO;
using SendEmail.Services;

namespace SendEmail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailingController : ControllerBase
    {
        private readonly IMailServices _mailServices;

        public MailingController(IMailServices mailServices)
        {
            _mailServices = mailServices;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromForm]MailRequestDto mailRequest)
        {
            var result = await _mailServices.SendEmail(mailRequest.MailTo, mailRequest.Subject, mailRequest.Body, mailRequest.Attachments);
            return Ok(result);
        }
    }
}
