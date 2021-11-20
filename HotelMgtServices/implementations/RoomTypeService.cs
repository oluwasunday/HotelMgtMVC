using HotelMgtModel.Dtos;
using HotelMgtModel.Utilities;
using HotelMgtModel.ViewModels;
using HotelMgtServices.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMgtServices.implementations
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IHttpRequestFactory _requestFactory;

        public RoomTypeService(IHttpRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }

        public async Task<IEnumerable<RoomTypeDto>> GetRoomTypesAsync()
        {
            var response = await _requestFactory.GetRequestAsync<Response<IEnumerable<RoomTypeDto>>>(requestUrl: $"api/rooms/roomtypes");

            return response.Data;
        }

        public async Task<RoomTypeDto> GetRoomTypeByIdAsync(string roomTypeId)
        {
            var response = await _requestFactory.GetRequestAsync<Response<RoomTypeDto>>(requestUrl: $"api/rooms/roomtype/{roomTypeId}");

            return response.Data;
        }

        public async Task<RoomTypeDto> DeleteRoomTypeByIdAsync(string roomTypeId)
        {
            var response = await _requestFactory.GetRequestAsync<Response<RoomTypeDto>>(requestUrl: $"api/rooms/roomtypes/{roomTypeId}");

            return response.Data;
        }
    }
}
