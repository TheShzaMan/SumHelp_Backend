using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SumHelpWebAPI.Models;


namespace SumHelpWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
        }
       
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ReportModel> Reports { get; set; }
        public DbSet<UserQuestionModel> UserQuestions { get; set; }
        public DbSet<SettingsModel> Settings { get; set; }
        public DbSet<ErrorLogModel> ErrorLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ErrorLogModel>()
                .HasOne(e => e.User)
                .WithMany(u => u.ErrorLogs)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<SettingsModel>()
                .HasOne(s => s.User)
                .WithMany(u => u.Settings)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<UserQuestionModel>()
                .HasOne(uq => uq.User)
                .WithMany(u => u.UserQuestions)
                .HasForeignKey(uq => uq.UserId);

            modelBuilder.Entity<ReportModel>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reports)
                .HasForeignKey(r => r.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }

}

