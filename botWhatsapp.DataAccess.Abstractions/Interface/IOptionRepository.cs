using botWhatsapp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace botWhatsapp.DataAccess.Abstractions.Interface
{
    public interface IOptionRepository
    {
        Task <IEnumerable<Option>> getAllOption();
        Task <Option?> getByIdOption(Int32 id);
        Task addOption(Option options);
        Task updateOption(Option options);
        Task updateState(Int32 id, Boolean state);
    }
}
