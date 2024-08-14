using System;
using System.ComponentModel.DataAnnotations;

namespace SumHelpWebAPI.Models
{
   public class ErrorLogModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }

        [Required]
        public string ErrorMessage { get; set; } // Stores the error message

        public string StackTrace { get; set; } // Stores the stack trace, if available

        [Required]
        public DateTime OccurredAt { get; set; } // Stores the timestamp when the error occurred

        public string Module { get; set; } // Stores the module or feature where the error occurred

        public string AdditionalInfo { get; set; } // Optional field for any additional information

        public string DeviceInfo { get; set; } // Stores information about the user's device
    }
}
