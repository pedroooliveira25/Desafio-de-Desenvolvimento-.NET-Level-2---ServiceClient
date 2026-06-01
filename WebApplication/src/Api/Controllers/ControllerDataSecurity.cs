
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/password")]
public class ControllerPassword : ControllerBase
{
    public readonly IPasswordHasher _passwordHasher;
    public readonly CreatePassword _createPassword;

    public readonly ICrudRepository<DataSecurity> _crudRepository;

    public ControllerPassword(IPasswordHasher passwordHasher, CreatePassword createPassword, ICrudRepository<DataSecurity> crudRepository)
    {
        _passwordHasher = passwordHasher; 
        _createPassword = createPassword;
        _crudRepository = crudRepository;
    }
  
    [Authorize]
    [HttpPost("set-password")]
    public async Task<IActionResult> SetPassword ([FromBody] RequestPasswordDtos request)
    {
         if (request == null)
            return BadRequest("Password is invalid");

        var createPassword = await _createPassword.Execute(request);  
        return Ok(createPassword);
    }
    [Authorize]
    [HttpGet("{id}")]

     public async Task<IActionResult> GetById(Guid id)
    {
        var password = await _crudRepository.GetByIdAsync(id);

        if (password == null)
            return NotFound();

        return Ok(password);
    }


    [Authorize]
    [HttpPut("{id}")]
     public async Task<IActionResult> Update (Guid id, [FromBody] RequestPasswordDtos request)
    {
        if (request == null)
        return BadRequest("Request is invalid");

        var dataSecurity = await _crudRepository.GetByIdAsync(id);

        if (dataSecurity == null)
        return NotFound();    

        dataSecurity.PasswordKey = _passwordHasher.Hash(request.Password);
        
        await _crudRepository.UpdateAsync(dataSecurity);

        return NoContent();

    }

    [Authorize]
    [HttpDelete("{id}")]
     public async Task<IActionResult> Delete (Guid id)
    {
        await _crudRepository.DeleteAsync(id);
        return NoContent();
    }

}