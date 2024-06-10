using System;

namespace DevRoom.Application.Features.Users.Commands.Login
{
    public class LoginDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}