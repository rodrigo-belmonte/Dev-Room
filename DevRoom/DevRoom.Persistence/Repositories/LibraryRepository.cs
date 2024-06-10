using DevRoom.Application.Contracts.Persistence;
using DevRoom.Domain.Entities;

namespace DevRoom.Persistence.Repositories
{
    public class LibraryRepository : BaseRepository<Library>, ILibraryRepository
    {
        public LibraryRepository(DevRoomDbContext dbContext) : base(dbContext)
        {

        }
    }
}
