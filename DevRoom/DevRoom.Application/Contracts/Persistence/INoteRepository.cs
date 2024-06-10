using DevRoom.Domain.Entities;

namespace DevRoom.Application.Contracts.Persistence
{
    public interface INoteRepository : IAsyncRepository<Note>
    {

    }
}
