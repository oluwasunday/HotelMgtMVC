using HotelMgtModel.Dtos;
using HotelMgtModel.Dtos.AuthDtos;
using System.Collections.Generic;

namespace HotelMgtModel.ViewModels
{
    public class HomeViewModel
    {
        public AuthenticatedUserDto AuthUser { get; set; }
        public ICollection<RoomTypeDto> RoomTypes { get; set; }
        public ICollection<RatingDto> Ratings { get; set; }
    }
}
