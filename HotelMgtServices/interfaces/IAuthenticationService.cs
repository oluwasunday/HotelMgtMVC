using HotelMgtModel.Dtos.AuthDtos;
using HotelMgtModel.Utilities;
using HotelMgtModel.ViewModels;
using System.Threading.Tasks;

namespace HotelMgtServices.interfaces
{
    public interface IAuthenticationService
    {
        Task<Response<LoginViewModel>> Login(LoginDto loginDto);
        Task<RegisterDto> Register(RegisterDto registerdto);
    }
}