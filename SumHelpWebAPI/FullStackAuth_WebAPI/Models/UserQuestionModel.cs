using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.Models
{
    public class UserQuestionModel
    {
      

      
    [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
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

        // Additional properties can be added as needed, for example:
        // public string Language { get; set; } // To store the language of the question
        // public double ResponseTime { get; set; } // To store how long it took to generate the response
    }
}
