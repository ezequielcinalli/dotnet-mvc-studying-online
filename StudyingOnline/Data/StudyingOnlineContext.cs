#nullable disable

using Microsoft.EntityFrameworkCore;
using StudyingOnline.Models;

public class StudyingOnlineContext : DbContext
{
    public StudyingOnlineContext(DbContextOptions<StudyingOnlineContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Category { get; set; }
    public DbSet<Course> Course { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Comment> Comment { get; set; }
}
