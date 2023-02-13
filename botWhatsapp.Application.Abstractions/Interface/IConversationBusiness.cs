using botWhatsapp.Common.TransferObjects;
using botWhatsapp.Common.TransferObjects.Conversation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace botWhatsapp.Application.Abstractions.Interface
{
    public interface IConversationBusiness
    {
        Task<IEnumerable<ConversationList>> GetAll();
        Task<ConversationList> GetConversationById(Int32 id);
        Task<ConversationList> Conversation(ConversationSave conversation);
        Task<Int32> addConversation(ConversationSave conversation);
        Task<Boolean> updateConversation(ConversationSave conversation);
        Task<Boolean> updateState(Int32 id, Boolean state);
    }
}
