using DevRoom.Application.Responses;
using DevRoom.Domain.Entities;

namespace DevRoom.Application.Features.Users.Commands.Login
{
    public class LoginCommandResponse: BaseResponse
    {
        public LoginCommandResponse(): base()
        {
            
        }

        public LoginDto User { get; set; }
        public string Token { get; set; }
        
        
    }
}