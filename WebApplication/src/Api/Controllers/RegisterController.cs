using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/register")]
public class RegisterController : ControllerBase
{
    private readonly CreateDataBasic _createDataBasic;
    private readonly CreateFinancial _createFinancial;
    private readonly CreateAddress _createAddress;
    private readonly CreatePassword _createPassword;

    private readonly RabbitPublisher _publisher;

    public RegisterController(
        CreateDataBasic createDataBasic,
        CreateFinancial createFinancial,
        CreateAddress createAddress,
        CreatePassword createPassword,
        RabbitPublisher createPublisher)
    {
        _createDataBasic = createDataBasic;
        _createFinancial = createFinancial;
        _createAddress = createAddress;
        _createPassword = createPassword;
        _publisher = createPublisher;
    }

    [HttpPost("full")]
    public async Task<IActionResult> RegisterFull([FromBody] RegisterFullDTO request)
    {
        if (request == null)
            return BadRequest("Invalid request");


        var basic = await _createDataBasic.Execute(request.DataBasic);

      
        var financial = await _createFinancial.Execute(request.Financial);


        var address = await _createAddress.Execute(request.Address);


        var password = await _createPassword.Execute(request.Security);

        _publisher.PublishCadastroEmail(
        request.DataBasic.Name,
        request.DataBasic.Email
);

        return Ok(new
        {
            basic,
            financial,
            address,
            password
        });
    }
}