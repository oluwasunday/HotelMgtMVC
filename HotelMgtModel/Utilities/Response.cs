using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HotelMgtModel.Utilities
{
    public class Response<T> where T : class
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }
        public Claim Claim { get; set; }
    }
}
