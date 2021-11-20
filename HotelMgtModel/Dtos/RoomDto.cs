using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMgtModel.Dtos
{
    public class RoomDto
    {
        public string Id { get; set; }
        public string RoomTypeId { get; set; }
        public string RoomNo { get; set; }
        public bool IsBooked { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
