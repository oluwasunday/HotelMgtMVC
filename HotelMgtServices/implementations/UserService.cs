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
    public class UserService : IUserService
    {
        private readonly IHttpRequestFactory _requestFactory;

        public UserService(IHttpRequestFactory httpRequestFactory)
        {
            _requestFactory = httpRequestFactory;
        }

        public async Task<UserDto> GetUserByIdAsync(string userId)
        {
            var result = await _requestFactory.GetRequestAsync<UserDto>($"/api/users/{userId}");
            return result;
        }
    }
}
