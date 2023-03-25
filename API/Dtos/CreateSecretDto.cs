using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
  public class CreateSecretDto
  {
    [Required]
    public string Body { get; set; }
    [Required]
    public int AccessAttemptsLeft { get; set; }

    [Required]
    public DateTime AvailableFrom { get; set; }
    [Required]
    public DateTime ExpiresAt { get; set; }
  }
}