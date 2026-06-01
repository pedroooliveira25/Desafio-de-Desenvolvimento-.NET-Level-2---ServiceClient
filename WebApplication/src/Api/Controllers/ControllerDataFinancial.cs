
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/financial")]
public class ControllerDataFinancial : ControllerBase
{
    public readonly CreateFinancial _createFiancial;

    public readonly ICrudRepository<DataFinancial> _crudRepository;

    public ControllerDataFinancial(CreateFinancial createFinacial, ICrudRepository<DataFinancial> crudRepository)
    {
        _createFiancial = createFinacial;
        _crudRepository = crudRepository;
    }
  
    [Authorize]
    [HttpPost("set-finance")]
    public async Task<IActionResult> SetFinance ([FromBody] DataFinancialDTOs request)
    {
         if (request == null)
            return BadRequest("Data is invalid");

        var createFinancial = await _createFiancial.Execute(request);  
        return Ok(createFinancial);
    }
    [Authorize]
    [HttpGet("{id}")]

     public async Task<IActionResult> GetById(Guid id)
    {
        var dataFinancial = await _crudRepository.GetByIdAsync(id);

        if (dataFinancial == null)
            return NotFound();

        return Ok(dataFinancial);
    }


    [Authorize]
    [HttpPut("{id}")]
     public async Task<IActionResult> Update (Guid id, [FromBody] DataFinancialDTOs request)
    {
        if (request == null)
        return BadRequest("Request is invalid");

        var dataFinancial = await _crudRepository.GetByIdAsync(id);

        if (dataFinancial == null)
        return NotFound();    

        dataFinancial.Finance = request.Finance;
        dataFinancial.Patrimony = request.Patrimony;
        
        await _crudRepository.UpdateAsync(dataFinancial);
        await _crudRepository.SaveChangesAsync();

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