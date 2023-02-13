namespace botWhatsapp.Common.TransferObjects
{
    public class UserList
    {
        #region atributos
        public Int32 Id { get; set; }
        public String Phone { get; set; } = default!;
        public String Name { get; set; }
        public Boolean State { get; set; }
        #endregion
        #region Relations
        public virtual ISet<ConversationList> Conversations { get; set; } = new HashSet<ConversationList>();
        #endregion
        #region Relations
        #endregion
    }
}
