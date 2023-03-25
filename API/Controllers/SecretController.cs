using API.Dtos;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class SecretController : BaseApiController
  {
    private readonly ISecretService _secretService;
    private readonly IMapper _mapper;
    private readonly ILogger<SecretController> _logger;
    private readonly IEncryptionService _encryptionService;
    public SecretController(
      ISecretService secretService,
      IMapper mapper, 
      ILogger<SecretController> logger, 
      IEncryptionService encryptionService)
    {
      _encryptionService = encryptionService;
      _logger = logger;
      _secretService = secretService;
      _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<SecretDto>> CreateSecret(CreateSecretDto createSecretDto) 
    {
      // var key1 = "d7c09386-c205-40ed-b2f4-50df5c7d2634";
      // _logger.LogInformation("ENCRYPTING:");
      // var encrypted = await _encryptionService.EncryptAsync(key1,createSecretDto.Body);
      // _logger.LogInformation(encrypted);
      // _logger.LogInformation("DECRYPTING:");
      // var key2 = "d7c09386-c205-40ed-b2f4-50df5c7d2634";
      // _logger.LogInformation(await _encryptionService.DecryptAsync(key2,encrypted));

      // return Ok();

      var secretDto = await _secretService.CreateSecretAsync(createSecretDto);
      if(secretDto != null) return Ok(secretDto);
      return BadRequest("Failed to create the secret");
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SecretDto>> GetSecret(Guid id)
    {
      // _logger.LogInformation(id);
      // var guid = new Guid(id);
      // _logger.LogInformation(guid.ToString());
      // return Ok(id);
      // var guid = new Guid(id);
      var secret = await _secretService.GetSecretAsync(id);
      if(secret == null) return NotFound("Secret Not Found");
      return secret;
      // var iidd = "d7c09386-c205-40ed-b2f4-50df5c7d2634";
      // var body =  "JBryZ023E2xzwnNc5a3AJg==";
      // var bb = await _encryptionService.DecryptAsync(iidd,body);
      // _logger.LogInformation(bb);
      // return Ok(bb);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SecretDto>>> GetSecrets()
    {
      var secrets = await _secretService.GetSecretsAsync();
      return Ok(_mapper.Map<IEnumerable<SecretDto>>(secrets));
    }
  }
}