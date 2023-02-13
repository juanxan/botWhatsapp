using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace botWhatsapp.Common.TransferObjects
{
    public class OptionList
    {
        #region Attributes
        public String Description { get; set; }
        public Int32 Order { get; set; }
        public Boolean State { get; set; }
        public Int32 RedirectionId { get; set; }
        #endregion
        #region Relations
        public Int32 ResponseId { get; set; }
        public virtual ResponseList Response { get; protected set; } = default!;
        #endregion
    }
}
