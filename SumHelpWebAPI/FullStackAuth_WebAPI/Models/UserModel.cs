using System;
using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.Models
{
    public class UserModel
    {


        [Key]
        public Guid UserId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }



        public DateTime? LastLogin { get; set; }

        // RevenueCat subscription status fields
        public string RevenueCatUserId { get; set; }

        public string SubscriptionStatus { get; set; }

        public DateTime? SubscriptionExpiration { get; set; }

        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        // Additional fields for user preferences


        //public ICollection<ErrorLogModel> ErrorLogs { get; set; }
        //public ICollection<SettingsModel> Settings { get; set; }
        public ICollection<UserQuestionModel> UserQuestions { get; set; }
        public ICollection<ReportModel> Reports { get; set; }
    }

}

