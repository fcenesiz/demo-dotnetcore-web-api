using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_dotnetcore_web_api.src.Dtos.Account
{
    public class NewUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}