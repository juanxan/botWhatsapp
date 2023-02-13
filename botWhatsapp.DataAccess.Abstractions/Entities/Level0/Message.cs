using GT.Transversal.Entities;


namespace botWhatsapp.Entities
{
    public  class Message : IdentityBase<Int32>
    {
        #region Attributes
        public String Type { get; set; }
        public String Reponse { get; set; }
        public Boolean State { get; set; }
        #endregion
        #region Relations
        public Int32 ConversationId { get; set; }
        public virtual Conversation Conversations { get; protected set; } = default!;
        public Int32 ResponseId { get; set; }
        public virtual Response Responses  { get; protected set; } = default!;
        #endregion
    }
}
