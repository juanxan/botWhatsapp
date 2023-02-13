using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace botWhatsapp.Common.TransferObjects
{
    public class ConversationHasExpired
    {
        public Int32 Id { get; set; }
        public Boolean IsExpired { get; set; }
    }
}
