using botWhatsapp.Common.TransferObjects;

namespace botWhatsapp.Application.Abstractions.Interface
{
    public interface IMessagesBusiness
    {
        Task<IEnumerable<MessageSave>> GetAllMessage();
        Task<MessageSave> GetByIdMessage(Int32 id);
        Task AddMessage(MessageSave messages);
        Task updateState(Int32 id, Boolean state);
        Task UpdateMessage(MessageSave messages);
    }
}
