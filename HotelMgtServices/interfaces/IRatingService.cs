using HotelMgtModel.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelMgtServices.interfaces
{
    public interface IRatingService
    {
        Task<RatingDto> GetRatingByIdAsync(string ratingId);
        Task<IEnumerable<RatingDto>> GetRatingsAsync();
    }
}