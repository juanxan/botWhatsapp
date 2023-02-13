using GT.Transversal.Entities;

namespace botWhatsapp.Entities
{
    public class Conversation : IdentityBase<Int32>
    {
        public Boolean State { get; set; }
        public DateTime Expiration { get; set; }
        #region Relations
        public Int32 UserId { get; set; }
        public virtual User User { get; protected set; } = default!;
        public virtual ISet<Message> Messages { get; protected set; } = new HashSet<Message>();
        #endregion

    }
}
