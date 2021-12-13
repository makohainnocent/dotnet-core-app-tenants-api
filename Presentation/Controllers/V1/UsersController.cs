using Application.Features.UsersFeatures.Commands;
using Application.Features.UsersFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Presentation;


 
namespace Presentation.Controllers.V1
{
 


[ApiVersion("1.0")]
public class UsersController : BaseApiController
{
    /// <summary>
    /// Creates a New Users.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateUsersCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    /// <summary>
    /// Gets all Users.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetAllUsersQuery()));
    }
    /// <summary>
    /// Gets Users Entity by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetUsersByIdQuery { userId = id }));
    }
    /// <summary>
    /// Deletes Users Entity based on Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await Mediator.Send(new DeleteUsersByIdCommand { userId = id }));
    }
    /// <summary>
    /// Updates the Users Entity based on Id.   
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateUsersCommand command)
    {
        if (id != command.userId)
        {
            return BadRequest();
        }
        return Ok(await Mediator.Send(command));
    }
}


}