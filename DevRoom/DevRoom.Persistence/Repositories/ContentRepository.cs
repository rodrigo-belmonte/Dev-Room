using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevRoom.Application.Contracts.Persistence;
using DevRoom.Domain.Entities;

namespace DevRoom.Persistence.Repositories
{
    public class ContentRepository : BaseRepository<Content>, IContentRepository
    {
        public ContentRepository(DevRoomDbContext dbContext) : base(dbContext)
        {
        }

        public Task<IReadOnlyList<Content>> ListAllContentsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
