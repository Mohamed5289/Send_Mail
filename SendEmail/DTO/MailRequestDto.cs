namespace SendEmail.DTO
{
    public class MailRequestDto
    {
        public string MailTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public IList<IFormFile>? Attachments { get; set; }
    }
}
