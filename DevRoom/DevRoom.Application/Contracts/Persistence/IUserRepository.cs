using DevRoom.Domain.Entities;
using System.Threading.Tasks;

namespace DevRoom.Application.Contracts.Persistence
{
    public interface IUserRepository: IAsyncRepository<User>
    {
        Task<User> LoginAsync(string user, string password);
         
    }
}