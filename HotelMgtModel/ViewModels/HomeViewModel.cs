using HotelMgtModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMgtModel.ViewModels
{
    public class HomeViewModel
    {
        public ICollection<RoomTypeDto> RoomTypes { get; set; }
        public ICollection<RatingDto> Ratings { get; set; }
    }
}
