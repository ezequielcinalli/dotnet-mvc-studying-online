using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StudyingOnline.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 6, ErrorMessage = "min 6, max 60 letters")]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "min 3, max 60 letters")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 2, ErrorMessage = "min 2, max 60 letters")]
    public string Name { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 6, ErrorMessage = "min 6, max 60 letters")]
    public string Phone { get; set; }

    public bool IsAdmin { get; set; } = false;
}