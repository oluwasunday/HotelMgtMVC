using HotelMgtModel.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelMgtServices.interfaces
{
    public interface IRoomService
    {
        Task<RoomDto> DeleteRoomByIdAsync(string roomNo);
        Task<RoomDto> GetRoomByIdAsync(string roomId);
        Task<IEnumerable<RoomDto>> GetRoomByRoomTypeIdAsync(string roomTypeId);
        Task<IEnumerable<RoomDto>> GetRoomsAsync();
    }
}