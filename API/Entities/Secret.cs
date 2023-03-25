using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
  public class Secret
  {
    [Key]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(4096)]
    public string Body { get; set; }
    public int AccessAttemptsLeft { get; set; }
    [Required]
    public DateTime AvailableFrom { get; set; }
    [Required]
    public DateTime ExpiresAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
  }
}