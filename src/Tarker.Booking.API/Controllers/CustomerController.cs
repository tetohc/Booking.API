using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.DeleteCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;
using Tarker.Booking.Domain.Models;

namespace Tarker.Booking.API.Controllers
{
    /// <summary>
    /// Controller for customer management.
    /// </summary>
    [Route("v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Create a new customer.
        /// </summary>
        /// <param name="model">Customer object.</param>
        /// <param name="createCustomerCommand">Command to create a customer.</param>
        /// <param name="validator">Customer model validator.</param>
        /// <returns></returns>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateCustomerModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseModel))]
        public async Task<IActionResult> Create([FromBody] CreateCustomerModel model,
            [FromServices] ICreateCustomerCommand createCustomerCommand,
            [FromServices] IValidator<CreateCustomerModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status400BadRequest, data: validate.Errors));

            var data = await createCustomerCommand.Execute(model);
            return StatusCode(statusCode: StatusCodes.Status201Created,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status201Created, data: data));
        }

        /// <summary>
        /// Updates the information of an existing customer.
        /// </summary>
        /// <param name="model">Model containing the updated customer data.</param>
        /// <param name="updateCustomerCommand">Command to execute the customer update.</param>
        /// <param name="validator">Validator for the customer update model.</param>
        /// <returns></returns>
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateCustomerModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseModel))]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerModel model,
            [FromServices] IUpdateCustomerCommand updateCustomerCommand,
            [FromServices] IValidator<UpdateCustomerModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status400BadRequest, data: validate.Errors));

            var data = await updateCustomerCommand.Execute(model);
            return StatusCode(statusCode: StatusCodes.Status200OK,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status200OK, data: data));
        }

        /// <summary>
        /// Deletes a customer by their ID.
        /// </summary>
        /// <param name="customerId">The ID of the customer to be deleted.</param>
        /// <param name="deleteCustomerCommand">Command to execute the customer deletion.</param>
        /// <returns></returns>
        [HttpDelete("Delete/{customerId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Delete(Guid customerId, [FromServices] IDeleteCustomerCommand deleteCustomerCommand)
        {
            if (customerId == Guid.Empty)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status400BadRequest));

            var data = await deleteCustomerCommand.Execute(customerId);
            if (!data)
                return StatusCode(statusCode: StatusCodes.Status404NotFound,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status404NotFound, data: data));

            return StatusCode(statusCode: StatusCodes.Status200OK,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status200OK, data: data));
        }

        /// <summary>
        /// Retrieves a customer list.
        /// </summary>
        /// <param name="getAllCustomerQuery">Query to get all customers.</param>
        /// <returns>Retrieve a list of customers.</returns>
        [HttpGet("Get-All")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetAllCustomerModel>))]
        public async Task<IActionResult> GetAll([FromServices] IGetAllCustomerQuery getAllCustomerQuery)
        {
            var data = await getAllCustomerQuery.Execute();
            return StatusCode(statusCode: StatusCodes.Status200OK,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status200OK, data: data));
        }

        /// <summary>
        /// Retrieve a customer by their ID.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        /// <param name="getCustomerByIdQuery">Query to get customer by their ID.</param>
        /// <returns>The customer that matches the specified ID.</returns>
        [HttpGet("Get-By-Id/{customerId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCustomerByIdModel))]
        public async Task<IActionResult> GetById(Guid customerId, [FromServices] IGetCustomerByIdQuery getCustomerByIdQuery)
        {
            if (customerId == Guid.Empty)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status400BadRequest));

            var data = await getCustomerByIdQuery.Execute(customerId);
            if (data == null)
                return StatusCode(statusCode: StatusCodes.Status404NotFound,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status404NotFound));

            return StatusCode(statusCode: StatusCodes.Status200OK,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status200OK, data: data));
        }

        /// <summary>
        /// Retrieve a customer by their document number.
        /// </summary>
        /// <param name="documentNumber">The document number used to retrieve the customer.</param>
        /// <param name="getCustomerByDocumentNumberQuery">Query to retrieve customer.</param>
        /// <returns></returns>
        [HttpGet("Get-By-DocumentNumber/{documentNumber}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCustomerByDocumentNumberModel))]
        public async Task<IActionResult> GetByDocumentNumber(string documentNumber, [FromServices] IGetCustomerByDocumentNumberQuery getCustomerByDocumentNumberQuery)
        {
            if (string.IsNullOrEmpty(documentNumber))
                return StatusCode(statusCode: StatusCodes.Status400BadRequest,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status400BadRequest));

            var data = await getCustomerByDocumentNumberQuery.Execute(documentNumber);
            if (data == null)
                return StatusCode(statusCode: StatusCodes.Status404NotFound,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status404NotFound));

            return StatusCode(statusCode: StatusCodes.Status200OK,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status200OK, data: data));
        }
    }
}