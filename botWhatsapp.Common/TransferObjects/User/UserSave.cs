using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace botWhatsapp.Common.TransferObjects
{
    public class UserSave
    {
        public String Phone { get; set; } = default!;
        public String Name { get; set; }
        public Boolean State { get; set; }
    }
}
