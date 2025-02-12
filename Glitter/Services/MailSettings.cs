namespace Glitter.Services
{
    public class MailSettings
    {
        public string? Host { get; set; }
        public int SMTPPort { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int IMAPPort { get; set; }
        public bool EnableSsl { get; set; }
    }
}
