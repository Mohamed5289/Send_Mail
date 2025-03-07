namespace SendEmail.Services
{
    public interface IMailServices
    {
        Task<string> SendEmail(string mailTo, string subject, string body, IList<IFormFile>? attachments = null);
    }
}
