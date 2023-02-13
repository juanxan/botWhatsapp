using botWhatsapp.Common.TransferObjects;
using botWhatsapp.DataAccess.Abstractions.Interface;
using botWhatsapp.DataAccess.DbContext;
using botWhatsapp.Entities;
using Microsoft.EntityFrameworkCore;

namespace botWhatsapp.DataAccess.Repositories
{
    public class ConversatioRepository : IConversationRepository
    {
        private readonly botDbContext _dbContext;

        public ConversatioRepository(botDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        async Task<IEnumerable<Conversation>> IConversationRepository.GetAll()
            => await this._dbContext.Set<Conversation>().ToListAsync();

        async Task<Conversation> IConversationRepository.GetConversationById(Int32 id)
            => await this._dbContext.Set<Conversation>().Where(m => m.Id.Equals(id)).FirstOrDefaultAsync();
        async Task<Int32> IConversationRepository.addConversation(Conversation conversation)
        {
            await this._dbContext.AddAsync(conversation);
            await this._dbContext.SaveChangesAsync();
            return conversation.Id;
        }

        async Task<Boolean> IConversationRepository.updateConversation(Conversation conversation)
        {
            if (await this._dbContext.Set<Conversation>().Where(x => x.Id.Equals(conversation.Id)).FirstOrDefaultAsync() is Conversation conversationDb)
            {
                this._dbContext.Entry(conversation).CurrentValues.SetValues(conversation);
                await this._dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        async Task<Boolean> IConversationRepository.updateState(Int32 id, Boolean state)
        {
            if (await this._dbContext.Set<Conversation>().Where(x => x.Id.Equals(id)).FirstOrDefaultAsync() is Conversation conversationDb)
            {
                conversationDb.State = state;
                await this._dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        async Task<Int32?> IConversationRepository.HasExpired(Int32 userId)
            => await this._dbContext.Set<Conversation>().Where(x => x.UserId.Equals(userId) && x.CreationTime >= DateTime.UtcNow && x.CreationTime < DateTime.UtcNow.AddDays(1))
                .Select(x => (Int32?)x.Id).FirstOrDefaultAsync();

        
}
