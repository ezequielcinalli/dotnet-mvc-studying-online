#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudyingOnline.Models;

public class StudyingOnlineContext : IdentityDbContext<IdentityUser>
{
    public StudyingOnlineContext(DbContextOptions<StudyingOnlineContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Category { get; set; }
    public DbSet<Course> Course { get; set; }
    public DbSet<Comment> Comment { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            }
        );
        base.OnModelCreating(modelBuilder);
    }
}
