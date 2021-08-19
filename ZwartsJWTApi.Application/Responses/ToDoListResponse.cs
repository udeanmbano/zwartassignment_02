using System;
using System.Collections.Generic;
using System.Text;

namespace ZwartsJWTApi.Application.Responses
{
   public  class ToDoListResponse
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}
