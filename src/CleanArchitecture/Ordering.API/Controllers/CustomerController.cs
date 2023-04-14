using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Commands;
using Ordering.Application.Response;
using Ordering.Core.Entities;

namespace Ordering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<List<Customer>> GetAll()
        {
            return await _mediator.Send(new GetAllCustomerQuery());

        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<Customer> Get (Guid Id)
        {
            return await _mediator.Send(new GetCustomerByIdQuery(Id));
        }

        [HttpGet("email")]
        [ProducesResponseType(200)]
        public async Task<Customer> GetbyEmail(string Email)
        {
            return await _mediator.Send(new GetCustomerByEmailQuery(Email));
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult<CustomerResponse>> CreateCustomer([FromBody] CreateCustomerCommand command )
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("EditCustomer/{id}")]
        public async Task<ActionResult> EditCustomer(Guid Id, [FromBody] EditCustomerCommand command)
        {
            try
            {
                if (command.Id == Id)
                {
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<ActionResult> DeleteCustomer(Guid Id)
        {
            try
            {
                string result = string.Empty;
                result = await _mediator.Send(new DeleteCustomerCommand(Id));
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

    }
}
