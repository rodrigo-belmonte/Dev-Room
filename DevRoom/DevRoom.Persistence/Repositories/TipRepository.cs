using DevRoom.Application.Contracts.Persistence;
using DevRoom.Domain.Entities;

namespace DevRoom.Persistence.Repositories
{
    public class TipRepository : BaseRepository<Tip>, ITipRepository
    {
        public TipRepository(DevRoomDbContext dbContext) : base(dbContext)
        {
        }
    }
}
