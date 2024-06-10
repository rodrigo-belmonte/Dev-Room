using DevRoom.Application.Contracts.Persistence;
using DevRoom.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevRoom.Persistence.Repositories
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(DevRoomDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddRangeAsync(IList<Tag> tags)
        {
            await _dbContext.AddRangeAsync(tags);
            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> IsTagNameUnique(string name)
        {
            return _dbContext.Tags.AnyAsync(e => e.Name.Equals(name));
        }

        public Task<bool> IsTagNameUnique(string name, Guid id)
        {
            return _dbContext.Tags.AnyAsync(e => e.Name.Equals(name) && e.Id != id);
        }

        public async Task<IReadOnlyList<Tag>> ListAllByIdAsync(Guid Id)
        {
            return await _dbContext.Tags.Where(tag => tag.Id != Id).ToListAsync();
        }
    }
}
