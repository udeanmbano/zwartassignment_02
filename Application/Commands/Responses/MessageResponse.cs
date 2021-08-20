using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZwartsJWTApi.Application.Commands.Responses
{
    public class MessageResponse
    {
        public int ResponseCode { get; set; }

        public int StatusCode { get; set; }

        public string Message { get; set; }
    }
}
