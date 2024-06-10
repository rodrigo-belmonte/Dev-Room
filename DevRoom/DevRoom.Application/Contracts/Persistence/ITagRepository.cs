using DevRoom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevRoom.Application.Contracts.Persistence
{
    public interface ITagRepository : IAsyncRepository<Tag>
    {
        Task<bool> IsTagNameUnique(string name);
        Task<bool> IsTagNameUnique(string name, Guid id);
        Task AddRangeAsync(IList<Tag> tags);
        Task<IReadOnlyList<Tag>> ListAllByIdAsync(Guid Id);
    }
}
