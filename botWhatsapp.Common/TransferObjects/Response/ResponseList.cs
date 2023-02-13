using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace botWhatsapp.Common.TransferObjects
{
    public class ResponseList
    {
        #region Attributes
        public Int32 Id { get; set; }
        public string Description { get; set; }
        public Boolean State { get; set; }

        public string Type { get; set; }
        #endregion
        #region Relations
        public virtual MessageList Messages { get; set; }
        public virtual ISet<OptionList> Options { get; protected set; } = new HashSet<OptionList>();

        #endregion
    }
}
