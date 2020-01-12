using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Alinta.Application.Commands.CreateCustomer;
using Alinta.Application.Commands.DeleteCustomer;
using Alinta.Application.Commands.UpdateCustomer;
using Alinta.Application.Queries.SearchCustomers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alinta.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Read

        [Route("")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Search([FromQuery] string search)
        {
            var customers = await _mediator.Send(new SearchCustomersQuery(search));
            return Ok(customers);
        }

        #endregion

        #region Write

        [Route("")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
        {
            var createdCustomer = await _mediator.Send(command);
            return Ok(createdCustomer);
        }

        [Route("{id}")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCustomerCommand command)
        {
            command.Id = id;
            var updatedCustomer = await _mediator.Send(command);
            return Ok(updatedCustomer);
        }

        [Route("{id}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _mediator.Send(new DeleteCustomerCommand(id));
            return Ok();
        }

        #endregion
    }
}