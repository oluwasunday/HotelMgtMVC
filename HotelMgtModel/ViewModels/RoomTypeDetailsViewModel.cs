using HotelMgtModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMgtModel.ViewModels
{
    public class RoomTypeDetailsViewModel
    {
        public RoomTypeDto RoomType { get; set; }
        public ICollection<RoomDto> Rooms { get; set; }
    }
}
