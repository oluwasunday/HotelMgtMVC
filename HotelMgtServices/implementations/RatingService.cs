using HotelMgtModel.Dtos;
using HotelMgtModel.Utilities;
using HotelMgtServices.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMgtServices.implementations
{
    public class RatingService : IRatingService
    {
        private readonly IHttpRequestFactory _requestFactory;

        public RatingService(IHttpRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }

        public async Task<IEnumerable<RatingDto>> GetRatingsAsync()
        {
            var response = await _requestFactory.GetRequestAsync<Response<IEnumerable<RatingDto>>>(requestUrl: $"api/customers/ratings");

            return response.Data;
        }

        public async Task<RatingDto> GetRatingByIdAsync(string ratingId)
        {
            var response = await _requestFactory.GetRequestAsync<Response<RatingDto>>(requestUrl: $"api/customers/ratingId/{ratingId}");

            return response.Data;
        }
    }
}
