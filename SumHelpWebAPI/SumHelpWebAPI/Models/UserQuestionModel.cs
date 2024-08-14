using System;
using System.ComponentModel.DataAnnotations;

namespace SumHelpWebAPI.Models
{
    public class UserQuestionModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Question { get; set; }

        [Required]
        [MaxLength(4000)]
        public string Response { get; set; }

        public DateTime Timestamp { get; set; }

        [Required]
        public bool IsValid { get; set; }
    }
}
