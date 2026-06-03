
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/address")]
public class ControllerDataAddress: ControllerBase
{
    public readonly CreateAddress _createDataAddress;

    public readonly ICrudRepository<DataAddress> _crudRepository;

    public ControllerDataAddress(CreateAddress createAddress, ICrudRepository<DataAddress> crudRepository)
    {
         _createDataAddress=  createAddress;
        _crudRepository = crudRepository;
    }
  
   
    [HttpPost()]
    public async Task<IActionResult> SetAddress ([FromBody] DataAddressDTOs request)
    {
         if (request == null)
            return BadRequest("Address is invalid");

        var createAddress = await _createDataAddress.Execute(request);  
        return Ok(createAddress);
    }
  
    [HttpGet("{id}")]

     public async Task<IActionResult> GetById(Guid id)
    {
        var address = await _crudRepository.GetByIdAsync(id);

        if (address == null)
            return NotFound();

        return Ok(address);
    }



    [HttpPut("{id}")]
     public async Task<IActionResult> Update (Guid id, [FromBody] DataAddressDTOs request)
    {
        if (request == null)
        return BadRequest("Request address is invalid");

        var address= await _crudRepository.GetByIdAsync(id);

        if (address == null)
        return NotFound();    

        address.Cep = request.Cep;
        address.City = request.City;
        address.Road = request.Road;
        address.District = request.District;
        address.Stage = request.Stage;
        address.Number = request.Number;
        
        await _crudRepository.UpdateAsync(address);

        return NoContent();
    }


    [HttpDelete("{id}")]
     public async Task<IActionResult> Delete (Guid id)
    {
        await _crudRepository.DeleteAsync(id);
        return NoContent();
    }

}