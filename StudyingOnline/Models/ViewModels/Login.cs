using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StudyingOnline.Models;

public class Login
{
    [Required]
    [StringLength(60, MinimumLength = 6, ErrorMessage = "min 6, max 60 letters")]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "min 3, max 60 letters")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}