using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetAllBookingQuery
{
    public class GetAllBookingQuery : IGetAllBookingQuery
    {
        private readonly IDataBaseService _dataBaseService;

        public GetAllBookingQuery(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetAllBookingModel>> Execute()
        {
            var result = await (from booking in _dataBaseService.Booking
                                join customer in _dataBaseService.Customer
                                on booking.CustomerId equals customer.CustomerId
                                select new GetAllBookingModel
                                {
                                    BookingId = booking.BookingId,
                                    Code = booking.Code,
                                    Type = booking.Type,
                                    RegisterDate = booking.RegisterDate,
                                    CustomerFullName = customer.FullName.Trim(),
                                    CustomerDocumentNumber = customer.DocumentNumber,
                                }).ToListAsync();
            return result;
        }
    }
}