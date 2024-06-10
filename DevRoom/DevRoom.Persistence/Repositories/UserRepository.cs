using DevRoom.Application.Contracts.Persistence;
using DevRoom.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevRoom.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DevRoomDbContext dbContext) : base(dbContext)
        {
        }


        public Task<User> LoginAsync(string username, string password)
        {
             return _dbContext.Users.Where(u => u.UserName == username && u.Password == password).FirstOrDefaultAsync();
        }

    }
}