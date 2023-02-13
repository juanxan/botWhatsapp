using botWhatsapp.DataAccess.Abstractions.Interface;
using botWhatsapp.DataAccess.DbContext;
using botWhatsapp.Entities;
using Microsoft.EntityFrameworkCore;

namespace botWhatsapp.DataAccess.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly botDbContext _dbContext;

        public MessageRepository(botDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        async Task IMessageRepository.addMessage(Message messages)
        {
            await this._dbContext.AddAsync(messages);
            await this._dbContext.SaveChangesAsync();
        }

        async Task<IEnumerable<Message>> IMessageRepository.getAllMessage()
            => await this._dbContext.Set<Message>().ToListAsync();

        async Task<Message?> IMessageRepository.getByIdMessage(Int32 id)
            => await this._dbContext.Set<Message>().Where(m => m.Id.Equals(id)).FirstOrDefaultAsync();

        async Task<Message?> IMessageRepository.getMessageByIdConversationLast(Int32 conversationId)
            => await this._dbContext.Set<Message>().Include(x => x.Reponse).Where(m => m.ConversationId.Equals(conversationId)).OrderByDescending(x => x.CreationTime).FirstOrDefaultAsync();

        async Task IMessageRepository.updateMessage(Message messages)
        {
            if(await this._dbContext.Set<Message>().Where(m => m.Id.Equals(messages.Id)).FirstOrDefaultAsync() is Message messageDb)
            {
                this._dbContext.Entry(messageDb).CurrentValues.SetValues(messages);
                await this._dbContext.SaveChangesAsync();
            }
            
        }

        async Task IMessageRepository.updateState(Int32 id, Boolean state)
        {
            if (await this._dbContext.Set<Message>().Where(m => m.Id.Equals(id)).FirstOrDefaultAsync() is Message messageDb)
            {
                messageDb.State = state;
                await this._dbContext.SaveChangesAsync();
            }
        }
    }
}
