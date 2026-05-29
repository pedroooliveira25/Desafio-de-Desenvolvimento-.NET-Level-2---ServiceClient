
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/password")]
public class ControllerPassword : ControllerBase
{
    public readonly IPasswordHasher _passwordHasher;
    public readonly CreatePassword _createPassword;

    public ControllerPassword(IPasswordHasher passwordHasher, CreatePassword createPassword)
    {
        _passwordHasher = passwordHasher; 
        _createPassword = createPassword;
    }

    [Authorize]
    [HttpPost("password")]

    public async Task<IActionResult> CreatePassword (RequestPasswordDtos request)
    {
        
    }
}