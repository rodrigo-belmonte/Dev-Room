using DevRoom.Application.Features.Users.Commands.Login;
using DevRoom.Domain.Entities;

namespace DevRoom.Application.Contracts.Infrastructure
{
    public interface ITokenService
    {
         string GenerateToken(LoginDto user);
         
    }
}