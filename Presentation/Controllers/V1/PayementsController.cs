using Application.Features.PayementsFeatures.Commands;
using Application.Features.PayementsFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Presentation;


 
namespace Presentation.Controllers.V1
{
 


[ApiVersion("1.0")]
public class PayementsController : BaseApiController
{

     private readonly IPayementsRepository _repository = null;
     public PayementsController(IPayementsRepository repository)
    {
        _repository = repository;
    }


    /// <summary>
    /// Creates a New Payements.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreatePayementsCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    /// <summary>
    /// Gets all Payements.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        //return Ok(await Mediator.Send(new GetAllPayementsQuery()));
        return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(_repository.GetAll()));
    }
    /// <summary>
    /// Gets Payements Entity by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(_repository.GetById(id)));
    }
    /// <summary>
    /// Deletes Payements Entity based on Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await Mediator.Send(new DeletePayementsByIdCommand { payementId = id }));
    }
    /// <summary>
    /// Updates the Payements Entity based on Id.   
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdatePayementsCommand command)
    {
        if (id != command.payementId)
        {
            return BadRequest();
        }
        return Ok(await Mediator.Send(command));
    }
}


}