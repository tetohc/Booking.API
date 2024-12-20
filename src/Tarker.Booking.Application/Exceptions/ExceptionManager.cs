using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Application.Exceptions
{
    /// <summary>
    /// Exception Handler Filter.
    /// </summary>
    public class ExceptionManager : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exceptionInfo = ResponseApiService.Response(statusCode: StatusCodes.Status500InternalServerError, message: context.Exception.Message, data: null);
            context.Result = new ObjectResult(exceptionInfo);
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}