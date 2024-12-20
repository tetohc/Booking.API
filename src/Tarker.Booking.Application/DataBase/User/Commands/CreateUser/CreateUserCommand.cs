using AutoMapper;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.DataBase.User.Commands.CreateUser
{
    /// <summary>
    /// Clase de implementación.
    /// </summary>
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateUserCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<CreateUserModel> Execute(CreateUserModel model)
        {
            var entity = _mapper.Map<UserEntity>(model);
            entity.UserId = Guid.NewGuid();
            await _dataBaseService.User.AddAsync(entity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}