﻿using HotelMgtModel.Utilities;
using HotelMgtMVC.Dtos;
using System.Threading.Tasks;

namespace HotelMgtServices.interfaces
{
    public interface IBookingService
    {
        Task<Response<BookingResponseDto>> BookAsync(AddBookingDto bookingDto);
    }
}