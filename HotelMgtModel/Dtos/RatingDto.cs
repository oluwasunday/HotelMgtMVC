using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMgtModel.Dtos
{
    public class RatingDto
    {
        public string Id { get; set; }
        public int Ratings { get; set; }
        public string Comment { get; set; }
        public string CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
