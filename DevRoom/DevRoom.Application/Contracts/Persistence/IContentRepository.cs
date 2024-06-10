using DevRoom.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevRoom.Application.Contracts.Persistence
{
    public interface IContentRepository : IAsyncRepository<Content>
    {
         Task<IReadOnlyList<Content>> ListAllContentsAsync();
    }
}
