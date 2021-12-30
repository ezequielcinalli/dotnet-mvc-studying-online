using System.ComponentModel.DataAnnotations;

namespace StudyingOnline.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "min 3, max 60 letters")]
    public string Name { get; set; } = String.Empty;

    [Required]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "min 3, max 60 letters")]
    public string Description { get; set; } = String.Empty;

    public List<Course>? Courses { get; set; }
}