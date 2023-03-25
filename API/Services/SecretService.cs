using API.Dtos;
using API.Entities;
using API.Interfaces;

namespace API.Services
{
  public class SecretService : ISecretService
  {
    private readonly IEncryptionService _encryptionService;
    private readonly ISecretRepository _secretRepository;
    private readonly ILogger _logger;

    public SecretService(
      IEncryptionService encryptionService, 
      ISecretRepository secretRepository,
      ILogger<SecretService> logger
      )
    {
      _secretRepository = secretRepository;
      _logger = logger;
      _encryptionService = encryptionService;
    }

    public async Task<SecretDto> CreateSecretAsync(CreateSecretDto createSecretDto)
    {
      var accessKey = Guid.NewGuid();
      _logger.LogInformation("ENCRYPTING WITH KEY");
      _logger.LogInformation(accessKey.ToString());
      var encryptedBody = await _encryptionService.EncryptAsync(accessKey.ToString(), createSecretDto.Body);
      var secret = new Secret {
        Id = accessKey,
        Body = encryptedBody,
        AccessAttemptsLeft = createSecretDto.AccessAttemptsLeft,
        AvailableFrom = createSecretDto.AvailableFrom,
        ExpiresAt = createSecretDto.ExpiresAt
      };
      
      _secretRepository.AddSecret(secret);
      if(await _secretRepository.SaveAllAsync()) {
        var secretDto = new SecretDto {
          Id = secret.Id,
          Body = secret.Body,
        };
        return secretDto;
      }

      return null;
    }

    public async Task<SecretDto> GetSecretAsync(Guid id)
    {
      var secret =  await _secretRepository.GetSecret(id);
      if(secret == null) return null;

      _logger.LogInformation(secret.AccessAttemptsLeft+"");

      if(DateTime.Now > secret.ExpiresAt) {
        _secretRepository.RemoveSecret(secret);
        await _secretRepository.SaveAllAsync();
        return null;
      }

      if(DateTime.Now < secret.AvailableFrom) {
        return null;
      }

      if(secret.AccessAttemptsLeft > -1) {
        if(secret.AccessAttemptsLeft == 1) {
          // Delete
          _secretRepository.RemoveSecret(secret);
          await _secretRepository.SaveAllAsync();
          return null;
        } else {
          // Decrement
          secret.AccessAttemptsLeft--;
          _secretRepository.UpdateSecret(secret);
          await _secretRepository.SaveAllAsync();
        }
      }

      var key = id.ToString();
      var decryptedBody = await _encryptionService.DecryptAsync(key,secret.Body);
      return new SecretDto {
        Id = id,
        Body = decryptedBody
      };
    }

    public async Task<IEnumerable<Secret>> GetSecretsAsync()
    {
      return await _secretRepository.GetSecrets();
    }
  }
}