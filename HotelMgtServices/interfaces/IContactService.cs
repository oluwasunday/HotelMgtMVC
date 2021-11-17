using HotelMgtModel.Dtos;
using HotelMgtModel.ViewModels;
using System.Threading.Tasks;

namespace HotelMgtServices.interfaces
{
    public interface IContactService
    {
        Task<AddContactViewModel> AddContactUsAsync(AddContactUsDto contactUsDto);
    }
}