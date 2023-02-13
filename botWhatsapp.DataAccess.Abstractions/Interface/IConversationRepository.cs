using botWhatsapp.Common.TransferObjects;
using botWhatsapp.Entities;

namespace botWhatsapp.DataAccess.Abstractions.Interface
{
    public interface IConversationRepository
    {
        Task<IEnumerable<Conversation>> GetAll();
        Task<Conversation> GetConversationById(Int32 id);
        Task<Int32> addConversation(Conversation conversation);
        Task<Boolean> updateConversation(Conversation conversation);
        Task<Boolean> updateState(Int32 id, Boolean state);
        Task<Int32?> HasExpired(Int32 userId);
    }
}
