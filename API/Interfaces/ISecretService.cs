using API.Dtos;
using API.Entities;

namespace API.Interfaces
{
  public interface ISecretService
  {
    Task<SecretDto> CreateSecretAsync(CreateSecretDto createSecretDto);
    Task<SecretDto> GetSecretAsync(Guid id);
    Task<IEnumerable<Secret>> GetSecretsAsync();
  }
}