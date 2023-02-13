using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace botWhatsapp.Common.TransferObjects
{
    public class ConversationList
    {
        public Int32 Id { get; set; }
        public Boolean State { get; set; }
        public DateTime Expiration { get; set; }
        #region Relations
        public Int32 UserId { get; set; }
        public virtual UserList User { get; protected set; } = default!;
        public virtual ISet<MessageList> Messages { get; protected set; } = new HashSet<MessageList>();
        #endregion
    }
}
