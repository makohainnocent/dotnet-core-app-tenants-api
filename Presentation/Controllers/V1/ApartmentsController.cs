using Application.Features.ApartmentsFeatures.Commands;
using Application.Features.ApartmentsFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Presentation;


 
namespace Presentation.Controllers.V1
{
 


[ApiVersion("1.0")]
public class ApartmentsController : BaseApiController
{
    /// <summary>
    /// Creates a New Apartments.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateApartmentsCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    /// <summary>
    /// Gets all Apartments.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetAllApartmentsQuery()));
    }
    /// <summary>
    /// Gets Apartments Entity by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetApartmentsByIdQuery { apartmentId = id }));
    }
    /// <summary>
    /// Deletes Apartments Entity based on Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await Mediator.Send(new DeleteApartmentsByIdCommand { apartmentId = id }));
    }
    /// <summary>
    /// Updates the Apartments Entity based on Id.   
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateApartmentsCommand command)
    {
        if (id != command.apartmentId)
        {
            return BadRequest();
        }
        return Ok(await Mediator.Send(command));
    }
}


}