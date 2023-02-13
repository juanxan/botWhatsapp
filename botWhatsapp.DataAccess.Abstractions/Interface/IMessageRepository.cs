using botWhatsapp.Entities;


namespace botWhatsapp.DataAccess.Abstractions.Interface
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> getAllMessage();
        Task<Message?> getByIdMessage(Int32 id);
        Task addMessage(Message messages);
        Task updateState(Int32 id, Boolean state);
        Task updateMessage(Message messages);
        Task<Message?> getMessageByIdConversationLast(Int32 id);
    }
}
