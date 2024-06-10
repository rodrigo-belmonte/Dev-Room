using MediatR;

namespace DevRoom.Application.Features.Users.Commands.Login
{
    public class LoginCommand: IRequest<LoginCommandResponse>
    {
        public string User { get; set; }
        public string Password { get; set; }
        
    }
}