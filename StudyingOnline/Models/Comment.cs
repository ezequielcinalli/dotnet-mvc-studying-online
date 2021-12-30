using System.ComponentModel.DataAnnotations;

namespace StudyingOnline.Models;

public class Comment
{
    public int Id { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 2, ErrorMessage = "min 2 max 60 letters")]
    public string Content { get; set; } = String.Empty;

    [Required]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    [Required]
    [Range(1, 5)]
    public int Score { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int CourseId { get; set; }
    public Course? Course { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int UserId { get; set; }
    public User? User { get; set; }

}
