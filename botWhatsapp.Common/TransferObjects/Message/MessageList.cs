

namespace botWhatsapp.Common.TransferObjects
{
    public class MessageList
    {
        #region Attributes
        public Int32 Id { get; set; }
        public String Type { get; set; }
        public String Reponse { get; set; }
        public Boolean State { get; set; }
        #endregion
        #region Relations
        public Int32 ResponseId { get; set; }
        public virtual ResponseList Responses { get; protected set; } = default!;
        #endregion
    }
}
