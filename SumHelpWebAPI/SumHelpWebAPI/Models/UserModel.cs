using System;
using System.ComponentModel.DataAnnotations;

namespace SumHelpWebAPI.Models
{
    public class UserModel
    {
        [Key]
        public Guid UserId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastLogin { get; set; }

        // RevenueCat subscription status fields
        public string RevenueCatUserId { get; set; }

        public string SubscriptionStatus { get; set; }

        public DateTime? SubscriptionExpiration { get; set; }

        // Additional fields for user preferences
        public string LanguagePreference { get; set; } = "en";

        public bool IsActive { get; set; } = true;

        public ICollection<ErrorLogModel> ErrorLogs { get; set; }
        public ICollection<SettingsModel> Settings { get; set; }
        public ICollection<UserQuestionModel> UserQuestions { get; set; }
        public ICollection<ReportModel> Reports { get; set; }
    }

}

