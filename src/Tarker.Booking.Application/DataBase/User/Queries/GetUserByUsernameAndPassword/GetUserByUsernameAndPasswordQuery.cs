using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.User.Queries.GetUserByUsernameAndPassword
{
    public class GetUserByUsernameAndPasswordQuery : IGetUserByUsernameAndPasswordQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetUserByUsernameAndPasswordQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetUserByUsernameAndPasswordModel> Execute(string username, string password)
        {
            var entity = await _dataBaseService.User
                .FirstOrDefaultAsync(x => x.UserName.Trim() == username.Trim() && x.Password.Trim() == password.Trim());
            return _mapper.Map<GetUserByUsernameAndPasswordModel>(entity);
        }
    }
}