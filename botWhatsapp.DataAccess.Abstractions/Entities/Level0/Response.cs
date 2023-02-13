using botWhatsapp.DataAccess.Abstractions.Entities;
using botWhatsapp.Entities;
using GT.Transversal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace botWhatsapp.Entities
{
    public class Response : IdentityBase<Int32>
    {
        #region Attributes
        public string Description { get; set; }
        public Boolean State { get; set; }

        public string Type { get; set; }
        #endregion
        #region Relations
        public virtual Message Messages { get; set; }
        public virtual ISet<Option> Options { get; protected set; } = new HashSet<Option>();

        #endregion
    }
}
