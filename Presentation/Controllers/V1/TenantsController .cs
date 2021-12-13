using Application.Features.TenantsFeatures.Commands;
using Application.Features.TenantsFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Presentation;
using System.Dynamic;
using System;
using System.Linq;
using System.Text.Json;


 
namespace Presentation.Controllers.V1
{
 


[ApiVersion("1.0")]
public class TenantsController : BaseApiController
{
    
     private readonly ITenantsRepository _repository = null;
     public TenantsController(ITenantsRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Creates a New Tenants.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateTenantsCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    /// <summary>
    /// Gets all Tenants.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        //return Ok(await Mediator.Send(new GetAllTenantsQuery()));
         return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(_repository.GetAll()));
    }
    /// <summary>
    /// Gets Tenants Entity by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        //return Ok(await Mediator.Send(new GetTenantsByIdQuery { tenantId = id }));
        return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(_repository.GetById(id)));
    }
    /// <summary>
    /// Deletes Tenants Entity based on Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await Mediator.Send(new DeleteTenantsByIdCommand { tenantId = id }));
    }
    /// <summary>
    /// Updates the Tenants Entity based on Id.   
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateTenantsCommand command)
    {
        if (id != command.tenantId)
        {
            return BadRequest();
        }
        return Ok(await Mediator.Send(command));
    }
}


}