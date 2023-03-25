namespace API.Interfaces
{
    public interface IEncryptionService
    {
        Task<string> EncryptAsync(string key, string plainString);
        Task<string> DecryptAsync(string key, string encryptedString);
    }
}