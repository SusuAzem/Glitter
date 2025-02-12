
namespace Glitter.Services
{
    public class MailData
    {
        public string? ClientId { get; set; }
        public string? ClientName { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public IFormFileCollection? EmailAttachments { get; set; }
    }
}
