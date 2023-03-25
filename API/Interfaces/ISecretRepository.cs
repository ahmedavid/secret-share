using API.Dtos;
using API.Entities;

namespace API.Interfaces
{
  public interface ISecretRepository
  {
    Secret AddSecret(Secret secret);
    void RemoveSecret(Secret secret);
    void UpdateSecret(Secret secret);
    Task<Secret> GetSecret(Guid id);
    Task<IEnumerable<Secret>> GetSecrets();
    Task<bool> SaveAllAsync();
  }
}