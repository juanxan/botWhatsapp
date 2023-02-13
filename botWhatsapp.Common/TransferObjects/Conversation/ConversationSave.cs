

namespace botWhatsapp.Common.TransferObjects
{
    public class ConversationSave
    {
        public Int32 Id { get; set; }
        public Boolean State { get; set; }
        public DateTime Expiration { get; set; }
        #region Relations
        public Int32 UserId { get; set; }
        #endregion

    }
}
