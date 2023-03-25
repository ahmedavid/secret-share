using API.Dtos;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
  public class SecretRepository : ISecretRepository
  {
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public SecretRepository(DataContext context, IMapper mapper)
    {
      _mapper = mapper;
      _context = context;
    }

    public Secret AddSecret(Secret secret)
    {
      _context.Secrets.Add(secret);
      return secret;
    }

    public void RemoveSecret(Secret secret)
    {
      _context.Secrets.Remove(secret);
    }

    public void UpdateSecret(Secret secret)
    {
      _context.Secrets.Update(secret);
    }

    public async Task<Secret> GetSecret(Guid id)
    {
      return await _context.Secrets.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Secret>> GetSecrets()
    {
      return await _context.Secrets.ToListAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
      int rows = await _context.SaveChangesAsync();
      return  rows > 0;
    }
  }
}