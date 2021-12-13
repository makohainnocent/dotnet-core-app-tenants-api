using Application.Features.RoomsFeatures.Commands;
using Application.Features.RoomsFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Presentation;


 
namespace Presentation.Controllers.V1
{
 


[ApiVersion("1.0")]
public class RoomsController : BaseApiController
{
    /// <summary>
    /// Creates a New Rooms.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateRoomsCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    /// <summary>
    /// Gets all Rooms.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetAllRoomsQuery()));
    }
    /// <summary>
    /// Gets Rooms Entity by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetRoomsByIdQuery { roomId = id }));
    }
    /// <summary>
    /// Deletes Rooms Entity based on Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await Mediator.Send(new DeleteRoomsByIdCommand { roomId = id }));
    }
    /// <summary>
    /// Updates the Rooms Entity based on Id.   
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateRoomsCommand command)
    {
        if (id != command.roomId)
        {
            return BadRequest();
        }
        return Ok(await Mediator.Send(command));
    }
}


}