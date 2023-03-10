using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace botWhatsapp.Common.TransferObjects
{
    public class OptionResponseList
    {
        public Int32 Id { get; set; }
        public Int32 OptionId { get; set; }
        public  OptionList Option { get;  set; } = default!;
        public Int32 MessageId { get; set; }
        public  MessageList Message { get;  set; } = default!;
    }
}
