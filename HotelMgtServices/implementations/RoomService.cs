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
    public class RoomService : IRoomService
    {
        private readonly IHttpRequestFactory _requestFactory;

        public RoomService(IHttpRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }

        public async Task<IEnumerable<RoomDto>> GetRoomsAsync()
        {
            var response = await _requestFactory.GetRequestAsync<Response<IEnumerable<RoomDto>>>(requestUrl: $"api/rooms");

            return response.Data;
        }

        public async Task<RoomDto> GetRoomByIdAsync(string roomId)
        {
            var response = await _requestFactory.GetRequestAsync<Response<RoomDto>>(requestUrl: $"api/rooms/{roomId}");

            return response.Data;
        }

        public async Task<IEnumerable<RoomDto>> GetRoomByRoomTypeIdAsync(string roomTypeId)
        {
            var response = await _requestFactory.GetRequestAsync<Response<IEnumerable<RoomDto>>>(requestUrl: $"api/rooms/type/{roomTypeId}");

            return response.Data;
        }

        public async Task<RoomDto> DeleteRoomByIdAsync(string roomNo)
        {
            var response = await _requestFactory.GetRequestAsync<Response<RoomDto>>(requestUrl: $"api/rooms/{roomNo}");

            return response.Data;
        }
    }
}
