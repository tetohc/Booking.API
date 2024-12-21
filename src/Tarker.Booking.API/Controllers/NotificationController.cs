using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.External.SendGridEmail;
using Tarker.Booking.Application.Features;
using Tarker.Booking.Domain.Models;
using Tarker.Booking.Domain.Models.SendGridEmail;

namespace Tarker.Booking.API.Controllers
{
    /// <summary>
    /// Notification Controller for sending emails.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class NotificationController : ControllerBase
    {
        /// <summary>
        /// Send Notification by email.
        /// </summary>
        /// <param name="model">SendGrid Email Request Model.</param>
        /// <param name="sendGridEmailService">Command to send notification.</param>
        /// <returns>
        /// Returns 201 Created if the email is sent successfully.
        /// Returns 500 Internal Server Error if there is a failure in sending the email.
        /// </returns>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BaseResponseModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseModel))]
        public async Task<IActionResult> SendNotification([FromBody] SendGridEmailRequestModel model,
            [FromServices] ISendGridEmailService sendGridEmailService)
        {
            bool result = await sendGridEmailService.Execute(model);
            if (!result)
                return StatusCode(statusCode: StatusCodes.Status500InternalServerError,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status500InternalServerError));

            return StatusCode(statusCode: StatusCodes.Status201Created,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status201Created));
        }
    }
}