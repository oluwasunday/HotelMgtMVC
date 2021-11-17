using HotelMgtModel.Dtos;
using HotelMgtModel.Utilities;
using HotelMgtModel.ViewModels;
using HotelMgtServices.interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMgtServices.implementations
{
    public class ContactService : IContactService
    {
        private readonly IHttpRequestFactory _requestFactory;

        public ContactService(IHttpRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }

        public async Task<AddContactViewModel> AddContactUsAsync(AddContactUsDto contactUsDto)
        {
            var response = await _requestFactory.PostRequestAsync<AddContactUsDto, Response<AddContactViewModel>>(
                    requestUrl: $"api/ContactUs/", contactUsDto);

            return response.Data;
        }
    }
}
