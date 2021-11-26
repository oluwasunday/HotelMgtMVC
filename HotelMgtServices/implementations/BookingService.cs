using HotelMgtModel.Utilities;
using HotelMgtMVC.Dtos;
using HotelMgtServices.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMgtServices.implementations
{
    public class BookingService : IBookingService
    {
        private readonly IHttpRequestFactory _requestFactory;

        public BookingService(IHttpRequestFactory httpRequestFactory)
        {
            _requestFactory = httpRequestFactory;
        }

        public async Task<Response<BookingResponseDto>> BookAsync(AddBookingDto bookingDto)
        {
            var result = await _requestFactory.PostRequestAsync<AddBookingDto, Response<BookingResponseDto>>("/api/Booking/create-booking", bookingDto);
            return result;
        }
    }
}
