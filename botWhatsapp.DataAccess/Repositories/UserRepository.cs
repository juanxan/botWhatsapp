using botWhatsapp.DataAccess.Abstractions.Interface;
using botWhatsapp.DataAccess.DbContext;
using botWhatsapp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace botWhatsapp.DataAccess.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly botDbContext _dbContext;
        public UserRepository(botDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        async Task<IEnumerable<User>> IUserRepository.getAllUser()
            => await this._dbContext.Set<User>().ToListAsync();

        async Task<User> IUserRepository.getByIdUser(Int32 id)
            => await this._dbContext.Set<User>().Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

        async Task<Int32> IUserRepository.addUser(User Users)
        {
            await this._dbContext.AddAsync(Users);
            await this._dbContext.SaveChangesAsync();
            return Users.Id;
        }

        
        async Task IUserRepository.updateUser(User Users)
        {
            if (await this._dbContext.Set<User>().Where(x => x.Id.Equals(Users.Id)).FirstOrDefaultAsync() is User userDb)
            {
                this._dbContext.Entry(userDb).CurrentValues.SetValues(Users);
                this._dbContext.SaveChanges();
            }
        }

        async Task IUserRepository.updateState(Int32 id, Boolean state)
        {
            if (await this._dbContext.Set<User>().Where(x => x.Id.Equals(id)).FirstOrDefaultAsync() is User userDb)
            {
                userDb.State = state;
                await this._dbContext.SaveChangesAsync();
            }
        }

        async Task<User> IUserRepository.getUserByPhone(string phone)
            => await this._dbContext.Set<User>().Where(x => x.Phone.Equals(phone)).FirstOrDefaultAsync();
    }
}
