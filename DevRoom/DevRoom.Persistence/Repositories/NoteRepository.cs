using DevRoom.Application.Contracts.Persistence;
using DevRoom.Domain.Entities;

namespace DevRoom.Persistence.Repositories
{
    public class NoteRepository : BaseRepository<Note>, INoteRepository
    {
        public NoteRepository(DevRoomDbContext dbContext) : base(dbContext)
        {
        }
    }
}
