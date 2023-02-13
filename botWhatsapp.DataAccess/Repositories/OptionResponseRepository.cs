using botWhatsapp.DataAccess.Abstractions.Entities;
using botWhatsapp.DataAccess.Abstractions.Interface;
using botWhatsapp.DataAccess.DbContext;
using Microsoft.EntityFrameworkCore;

namespace botWhatsapp.DataAccess.Repositories
{
    public class OptionResponseRepository : IOptionResponseRepository
    {
        private readonly botDbContext  _dbContext;

        public OptionResponseRepository(botDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        async Task<Int32> IOptionResponseRepository.AddOptionResponse(OptionResponse optionResponse)
        {
            await this._dbContext.Set<OptionResponse>().AddAsync(optionResponse);
            await this._dbContext.SaveChangesAsync();
            return optionResponse.Id;
        }

        async Task<IEnumerable<OptionResponse>> IOptionResponseRepository.GetAllOptionResponse()
            => await this._dbContext.Set<OptionResponse>().ToListAsync();

        async Task<OptionResponse> IOptionResponseRepository.GetOptionResponseById(Int32 id)
            => await this._dbContext.Set<OptionResponse>().Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
    }
}
