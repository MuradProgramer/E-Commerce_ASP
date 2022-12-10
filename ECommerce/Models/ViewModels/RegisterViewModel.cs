namespace ECommerce.Models.ViewModels;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(5)]
    public string Name { get; set; }
    [Required]
    [MinLength(5)]
    public string Surname { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}
