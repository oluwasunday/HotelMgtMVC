﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace HotelMgtModel.ViewModels
{
    public class LoginViewModel
    {
        [Required (ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Password To Continue")]
        public string Password { get; set; }
        public string Id { get; set; }
        public string Token { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
