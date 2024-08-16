
using System;
using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.Models
{
    public class ReportModel
    {
        [Key]
        public Guid ReportId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; }  // Foreign key to UserModel

        [Required]
        [MaxLength(100)]
        public string ReportType { get; set; }  // e.g., "Content", "Bug", "Other"

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }  // Description of the issue

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsResolved { get; set; } = false;

        public DateTime? ResolvedAt { get; set; }

        [MaxLength(500)]
        public string AdminResponse { get; set; }  // Response from the admin or support team

        public UserModel User { get; set; }
    }
}
