
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/dataBasic")]
public class ControllerDataBasic: ControllerBase
{
    public readonly CreateDataBasic _createDataBasic;

    public readonly ICrudRepository<DataBasic> _crudRepository;

    public ControllerDataBasic(CreateDataBasic createDataBasic, ICrudRepository<DataBasic> crudRepository)
    {
         _createDataBasic=  createDataBasic;
        _crudRepository = crudRepository;
    }
  

    [HttpPost("set-dataBasic")]
    public async Task<IActionResult> SetDataBasic ([FromBody] DataBasicDTOs request)
    {
         if (request == null)
            return BadRequest("The Data is invalid");

        var createDataBasic = await _createDataBasic.Execute(request);  
        return Ok(createDataBasic);
    }

    [HttpGet("{id}")]

     public async Task<IActionResult> GetById(Guid id)
    {
        var dataBasic = await _crudRepository.GetByIdAsync(id);

        if (dataBasic == null)
            return NotFound();

        return Ok(dataBasic);
    }



    [HttpPut("{id}")]
     public async Task<IActionResult> Update (Guid id, [FromBody] DataBasicDTOs request)
    {
        if (request == null)
        return BadRequest("Request data is invalid");

        var dataBasic= await _crudRepository.GetByIdAsync(id);

        if (dataBasic == null)
        return NotFound();    

        dataBasic.Cpf = request.Cpf;
        dataBasic.Name = request.Name;
        dataBasic.Email = request.Email;
        dataBasic.DateOfBirth = request.DateOfBith;
        dataBasic.Phone = request.Phone;
        
        await _crudRepository.UpdateAsync(dataBasic);

        return NoContent();
    }

  
    [HttpDelete("{id}")]
     public async Task<IActionResult> Delete (Guid id)
    {
        await _crudRepository.DeleteAsync(id);
        return NoContent();
    }

}