using HotelMgtModel.Dtos.AuthDtos;
using HotelMgtModel.Utilities;
using HotelMgtModel.ViewModels;
using HotelMgtServices.interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMgtServices.implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpRequestFactory _requestFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationService(IHttpRequestFactory requestFactory, IHttpContextAccessor httpContextAccessor)
        {
            _requestFactory = requestFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<LoginViewModel>> Login(LoginDto loginDto)
        {
            var handler = new JwtSecurityTokenHandler();

            var result = await _requestFactory.PostRequestAsync<LoginDto, Response<LoginViewModel>>("api/Auth/Login", loginDto);
            if (result.Succeeded)
            {
                _httpContextAccessor.HttpContext.Session.SetString("access_token", result.Data.Token);
                _httpContextAccessor.HttpContext.Session.SetString("user", JsonConvert.SerializeObject(result));
                JwtSecurityToken decodedValue = handler.ReadJwtToken(result.Data.Token);

                result.Data.Claims = decodedValue.Claims;

                return result;
            }
            return result;
        }

        public async Task<RegisterDto> Register(RegisterDto registerdto)
        {
            var result = await _requestFactory.PostRequestAsync<RegisterDto, Response<RegisterDto>>("api/Auth/Register", registerdto);
            return result.Data;
        }
    }
}
