using FullStackAuth_WebAPI.Configuration;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FullStackAuth_WebAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
       
        public DbSet<UserModel> AppUsers { get; set; }
        public DbSet<ReportModel> Reports { get; set; }
        public DbSet<UserQuestionModel> UserQuestions { get; set; }


        public ApplicationDbContext(DbContextOptions options)
    : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserQuestionModel>()
                .HasOne(uq => uq.User)
                .WithMany(u => u.UserQuestions)
                .HasForeignKey(uq => uq.UserId);

            modelBuilder.Entity<ReportModel>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reports)
                .HasForeignKey(r => r.UserId);

            modelBuilder.ApplyConfiguration(new RolesConfiguration());
        }
    }
}
