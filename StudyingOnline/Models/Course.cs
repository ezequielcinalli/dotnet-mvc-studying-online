using System.ComponentModel.DataAnnotations;

namespace StudyingOnline.Models;

public class Course
{
    public int Id { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "min 3, max 60 letters")]
    public string Name { get; set; } = String.Empty;

    [Required]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "min 3, max 60 letters")]
    public string Description { get; set; } = String.Empty;

    [Required]
    [Range(0, 120)]
    public int Duration { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Price { get; set; }

    public string? Image { get; set; }

    [Required]
    [Display(Name = "Category")]
    [Range(0, int.MaxValue)]
    public int CategoryId { get; set; }

    public Category? Category { get; set; }
}
