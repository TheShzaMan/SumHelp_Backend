
using System;
using System.ComponentModel.DataAnnotations;

namespace SumHelpWebAPI.Models
{
    public class ReportModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }

        [Required]
        [MaxLength(100)]
        public string ReportType { get; set; }  // e.g., "Content", "Bug", "Other"

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }  // Description of the issue

        [MaxLength(255)]
        public string ScreenshotUrl { get; set; }  // Optional link to a screenshot

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsResolved { get; set; } = false;

        public DateTime? ResolvedAt { get; set; }

        [MaxLength(500)]
        public string AdminResponse { get; set; }  // Response from the admin or support team
    }
}
