using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.DataBase.Booking.Commands.CreateBooking;
using Tarker.Booking.Application.DataBase.Booking.Queries.GetAllBookingQuery;
using Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingByDocumentNumber;
using Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingByType;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;
using Tarker.Booking.Domain.Models;

namespace Tarker.Booking.API.Controllers
{
    /// <summary>
    /// Controller for booking management.
    /// </summary>
    [Route("v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class BookingController : ControllerBase
    {
        /// <summary>
        /// Create a new booking.
        /// </summary>
        /// <param name="model">Booking object.</param>
        /// <param name="createBookingCommand">Command to create a booking.</param>
        /// <param name="validator">Booking model validator.</param>
        /// <returns>Response to the request.</returns>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateBookingModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseModel))]
        public async Task<IActionResult> Create([FromBody] CreateBookingModel model,
            [FromServices] ICreateBookingCommand createBookingCommand,
            [FromServices] IValidator<CreateBookingModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status400BadRequest, data: validate.Errors));

            var data = await createBookingCommand.Execute(model);
            return StatusCode(statusCode: StatusCodes.Status201Created,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status201Created, data: data));
        }

        /// <summary>
        /// Retrieve a list of all bookings.
        /// </summary>
        /// <param name="getAllBookingQuery">Query to get all bookings.</param>
        /// <returns>A list of bookings.</returns>
        [HttpGet("Get-All")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetAllBookingModel>))]
        public async Task<IActionResult> GetAll([FromServices] IGetAllBookingQuery getAllBookingQuery)
        {
            var data = await getAllBookingQuery.Execute();
            return StatusCode(statusCode: StatusCodes.Status200OK,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status200OK, data: data));
        }

        /// <summary>
        /// Retrieve a list of bookings filtered by document number.
        /// </summary>
        /// <param name="documentNumber">The document number used to filter bookings.</param>
        /// <param name="getBookingByDocumentNumberQuery">Query to retrieve the filtered list.</param>
        /// <returns>A list of bookings that match the specified document number.</returns>
        [HttpGet("Get-By-DocumentNumber")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetBookingByDocumentNumberModel>))]
        public async Task<IActionResult> GetByDocumentNumber([FromQuery] string documentNumber, [FromServices] IGetBookingByDocumentNumberQuery getBookingByDocumentNumberQuery)
        {
            if (string.IsNullOrWhiteSpace(documentNumber))
                return StatusCode(statusCode: StatusCodes.Status400BadRequest,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status400BadRequest));

            var data = await getBookingByDocumentNumberQuery.Execute(documentNumber);
            return StatusCode(statusCode: StatusCodes.Status200OK,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status200OK, data: data));
        }

        /// <summary>
        /// Retrieves a list of bookings filtered by its type.
        /// </summary>
        /// <param name="type">The type used to filter bookings.</param>
        /// <param name="getBookingByTypeQuery">Query to retrieve the filtered list.</param>
        /// <returns>A list of bookings that match the specified type.</returns>
        [HttpGet("Get-By-Type")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetBookingByTypeModel>))]
        public async Task<IActionResult> GetByType([FromQuery] string type, [FromServices] IGetBookingByTypeQuery getBookingByTypeQuery)
        {
            if (string.IsNullOrWhiteSpace(type))
                return StatusCode(statusCode: StatusCodes.Status400BadRequest,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status400BadRequest));

            var data = await getBookingByTypeQuery.Execute(type);
            return StatusCode(statusCode: StatusCodes.Status200OK,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status200OK, data: data));
        }
    }
}