using System.ComponentModel.DataAnnotations;

namespace SumHelpWebAPI.Models
{
    public class SettingsModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }

        // Example settings properties
        [Required]
        [MaxLength(10)]
        public string Language { get; set; } // Stores the user's preferred language, e.g., "en", "fr"

        [Required]
        public bool NotificationsEnabled { get; set; } // Stores whether the user has enabled notifications

        public string Theme { get; set; } // Stores the user's theme preference, e.g., "light", "dark"

        // Additional settings can be added as needed, for example:
        // public bool IsDarkMode { get; set; }
        // public string DefaultCurrency { get; set; } // Stores the user's preferred currency, e.g., "USD", "EUR"
        // public bool UseMetric { get; set; } // Stores whether the user prefers metric units

        public DateTime LastUpdated { get; set; } // Stores the timestamp of the last update to the settings
    }
}
