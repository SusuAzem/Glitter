using System.ComponentModel.DataAnnotations;

namespace Glitter.Models
{
    public class MessageViewModel
    {

        public MessageViewModel() 
        {
            Id = Guid.NewGuid();
            TimeSend = DateTime.Now;
            Interests = [];
            InterestCB = [];
        }
        public MessageViewModel(string name, string email, string content, string phoneNumber, string? company, string? subject)
        {
            Name = name;
            Email = email;
            Content = content;
            PhoneNumber = phoneNumber;
            Company = company;
            Subject = subject;
        }
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Subject { get; set; }
        [Required]
        public string? Content { get; set; }
        [Required]
        public string? Company { get; set; }

        public virtual List<Interest>? InterestCB { get; set; }

        public List<string>? Interests { get; set; }

        [Required]
        //[RegularExpression(@"^(05)(5|0|3|6|4|9|1|8|7)([0-9]{7})$", ErrorMessage = "05...")]
        public string? PhoneNumber { get; set; }

        public DateTime TimeSend { get; set; }
    }
}