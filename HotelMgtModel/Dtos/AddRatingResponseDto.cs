using System;

namespace HotelMgtModel.Dtos
{
    public class AddRatingResponseDto
    {
        public string Id { get; set; }
        public int Ratings { get; set; }
        public string Comment { get; set; }
        public string CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
