using botWhatsapp.DataAccess.Abstractions.Interface;
using botWhatsapp.DataAccess.DbContext;
using botWhatsapp.Entities;
using Microsoft.EntityFrameworkCore;

namespace botWhatsapp.DataAccess.Repositories
{
    public class OptionRepository : IOptionRepository
    {
        private readonly botDbContext _dbContext;

        public OptionRepository(botDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        async Task IOptionRepository.addOption(Option options)
        {
            await this._dbContext.AddAsync(options);
            await this._dbContext.SaveChangesAsync();
        }

        async Task<IEnumerable<Option>> IOptionRepository.getAllOption()
            => await this._dbContext.Set<Option>().Include(x => x.Response).Include(x => x.Response).ToListAsync();

        async Task<Option?> IOptionRepository.getByIdOption(Int32 id)
           => await _dbContext.Set<Option>().FindAsync(id);

        async Task IOptionRepository.updateOption(Option options)
        {
            if(await this._dbContext.Set<Option>().Where(m => m.Id.Equals(options.Id)).FirstOrDefaultAsync() is Option OptionDb)
            {
                this._dbContext.Entry(options).CurrentValues.SetValues(options);
                this._dbContext.SaveChangesAsync();
            }
        }
         
        async Task IOptionRepository.updateState(Int32 id, Boolean state)
        {
            if(await this._dbContext.Set<Option>().Where(m => m.Id.Equals(id)).FirstOrDefaultAsync() is Option optionDb)
            {
                optionDb.State = state;
                this._dbContext.SaveChangesAsync();
            }
        }
    }
}
