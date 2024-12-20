using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;
using Tarker.Booking.Application.DataBase.User.Commands.DeleteUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword;
using Tarker.Booking.Application.DataBase.User.Queries.GetAllUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserById;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserByUsernameAndPassword;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;
using Tarker.Booking.Domain.Models;

namespace Tarker.Booking.API.Controllers
{
    /// <summary>
    /// Controller for user management.
    /// </summary>
    [Route("[controller]")]
    [Produces("application/json")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="model">User object.</param>
        /// <param name="createUserCommand">Command to create a user.</param>
        /// <param name="validator">User model validator.</param>
        /// <returns></returns>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateUserModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseModel))]
        public async Task<IActionResult> Create([FromBody] CreateUserModel model,
            [FromServices] ICreateUserCommand createUserCommand,
            [FromServices] IValidator<CreateUserModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest, value: ResponseApiService.Response(statusCode: StatusCodes.Status400BadRequest, data: validate));

            var data = await createUserCommand.Execute(model);
            return StatusCode(statusCode: StatusCodes.Status201Created, value: ResponseApiService.Response(statusCode: StatusCodes.Status201Created, data: data));
        }

        /// <summary>
        /// Updates the information of an existing user.
        /// </summary>
        /// <param name="model">Model containing the updated user data.</param>
        /// <param name="updateUserCommand">Command to execute the user update.</param>
        /// /// <param name="validator">Validator for the user update model.</param>
        /// <returns></returns>
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateUserModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseModel))]
        public async Task<IActionResult> Update([FromBody] UpdateUserModel model,
            [FromServices] IUpdateUserCommand updateUserCommand,
            [FromServices] IValidator<UpdateUserModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status400BadRequest, data: validate));

            var data = await updateUserCommand.Execute(model);
            return StatusCode(statusCode: StatusCodes.Status200OK,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status200OK, data: data));
        }

        /// <summary>
        /// Update the user's password.
        /// </summary>
        /// <param name="model">Model containing the updated user's password.</param>
        /// <param name="updateUserPasswordCommand">Command to execute the user's password update.</param>
        /// <param name="validator">Validator for the user's password update model.</param>
        /// <returns></returns>
        [HttpPut("Update-Password")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateUserPasswordModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseModel))]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdateUserPasswordModel model,
            [FromServices] IUpdateUserPasswordCommand updateUserPasswordCommand,
            [FromServices] IValidator<UpdateUserPasswordModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status400BadRequest, data: validate));

            var data = await updateUserPasswordCommand.Execute(model);
            return StatusCode(statusCode: StatusCodes.Status200OK,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status200OK, data: data));
        }

        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user to be deleted.</param>
        /// <param name="deleteUserCommand">Command to execute the user deletion.</param>
        /// <returns></returns>
        [HttpDelete("Delete/{userId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Delete(Guid userId, [FromServices] IDeleteUserCommand deleteUserCommand)
        {
            if (userId == Guid.Empty)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status400BadRequest));

            var data = await deleteUserCommand.Execute(userId);

            if (!data)
                return StatusCode(statusCode: StatusCodes.Status404NotFound,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status404NotFound, data: data));

            return StatusCode(statusCode: StatusCodes.Status200OK,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status200OK, data: data));
        }

        /// <summary>
        /// Retrieves a user list.
        /// </summary>
        /// <param name="getAllUserQuery">Query to get all users.</param>
        /// <returns>A list of users.</returns>
        [HttpGet("Get-All")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetAllUserModel>))]
        public async Task<IActionResult> GetAll([FromServices] IGetAllUserQuery getAllUserQuery)
        {
            var data = await getAllUserQuery.Execute();
            if (data == null || data.Count == 0)
                return StatusCode(statusCode: StatusCodes.Status404NotFound,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status404NotFound, data: data));

            return StatusCode(statusCode: StatusCodes.Status200OK,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status200OK, data: data));
        }

        /// <summary>
        /// Retrieve a user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="getUserByIdQuery">Query to get user by their ID.</param>
        /// <returns>The user that matches the specified ID.</returns>
        [HttpGet("Get-by-Id/{userId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetUserByIdModel))]
        public async Task<IActionResult> GetById(Guid userId, [FromServices] IGetUserByIdQuery getUserByIdQuery)
        {
            if (userId == Guid.Empty)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status400BadRequest));

            var data = await getUserByIdQuery.Execute(userId);

            if (data == null)
                return StatusCode(statusCode: StatusCodes.Status404NotFound,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status404NotFound, data: data));

            return StatusCode(statusCode: StatusCodes.Status200OK,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status200OK, data: data));
        }

        /// <summary>
        /// Retrieve a user by their username and password.
        /// </summary>
        /// <param name="username">The username of user.</param>
        /// <param name="password">The password of user.</param>
        /// <param name="getUserByUsernameAndPasswordQuery">Query to get user by their username and password.</param>
        /// <param name="validator">Validator for the username and password.</param>
        /// <returns></returns>
        [HttpGet("Get-by-Username-Password/{username}/{password}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetUserByUsernameAndPasswordModel))]
        public async Task<IActionResult> GetByUsernamePassword(string username, string password,
            [FromServices] IGetUserByUsernameAndPasswordQuery getUserByUsernameAndPasswordQuery,
            [FromServices] IValidator<(string, string)> validator)
        {
            var validate = await validator.ValidateAsync((username, password));
            if (!validate.IsValid)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status400BadRequest, data: validate));

            var data = await getUserByUsernameAndPasswordQuery.Execute(username, password);
            if (data == null)
                return StatusCode(statusCode: StatusCodes.Status404NotFound,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status404NotFound, data: data));

            return StatusCode(statusCode: StatusCodes.Status200OK,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status200OK, data: data));
        }
    }
}