using HotelMgtModel.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelMgtServices.interfaces
{
    public interface IRoomTypeService
    {
        Task<RoomTypeDto> DeleteRoomTypeByIdAsync(string roomTypeId);
        Task<IEnumerable<AmenityDto>> GetAmenitiesForRoomTypeIdAsync(string roomTypeId);
        Task<RoomTypeDto> GetRoomTypeByIdAsync(string roomTypeId);
        Task<IEnumerable<RoomTypeDto>> GetRoomTypesAsync();
    }
}