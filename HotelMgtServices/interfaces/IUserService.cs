using HotelMgtMVC.Dtos;
using System.Threading.Tasks;

namespace HotelMgtServices.interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(string userId);
    }
}