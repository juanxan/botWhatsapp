

using botWhatsapp.DataAccess.Abstractions.Interface;
using botWhatsapp.DataAccess.DbContext;
using botWhatsapp.Entities;
using Microsoft.EntityFrameworkCore;

namespace botWhatsapp.DataAccess.Repositories
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly botDbContext _dbContext;
        public ResponseRepository(botDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task IResponseRepository.addResponse(Response responses)
        {
            await this._dbContext.AddAsync(responses);
            await this._dbContext.SaveChangesAsync();
        }

        async Task<IEnumerable<Response>> IResponseRepository.getAllResponse()
            => await this._dbContext.Set<Response>().Include(x => x.Options).ToListAsync();

        async Task<Response?> IResponseRepository.getByIdResponse(Int32 id)
            => await this._dbContext.Set<Response>().Include(x => x.Options).Where(m => m.Id.Equals(id)).FirstOrDefaultAsync();
        

        async Task IResponseRepository.UpdateResponse(Response responses)
        {
            if (await this._dbContext.Set<Response>().Where(m => m.Id.Equals(responses.Id)).FirstOrDefaultAsync() is Response responseDb)
            {
                this._dbContext.Entry(responseDb).CurrentValues.SetValues(responses);
                this._dbContext.SaveChangesAsync();
            }
        }

        async Task IResponseRepository.updateState(Int32 id, Boolean state)
        {
            if (await this._dbContext.Set<Response>().Where(m => m.Id.Equals(id)).FirstOrDefaultAsync() is Response responseDb)
            {
                responseDb.State = state;
                await this._dbContext.SaveChangesAsync();
            }
        }

        async Task<Response> IResponseRepository.WelcomeMessage()
            => await this._dbContext.Set<Response>().Where(x => x.Type.Equals("welcome")).FirstOrDefaultAsync();
    }
}
