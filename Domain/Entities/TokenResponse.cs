using System;
using System.Collections.Generic;
using System.Text;
using ZwartsJWTApi.Domain.Entities;

namespace ZwartsJWTApi.Domain.Entities
{
    public class TokenResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string token { get; set; }
        public string expiration { get; set; }
        public int userId { get; set; }


    }
}
