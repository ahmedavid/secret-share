using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
  public class SecretDto
  {
    public Guid Id { get; set; }
    public string Body { get; set; }
  }
}