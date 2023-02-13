using botWhatsapp.Common.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace botWhatsapp.Application.Abstractions.Interface
{
    public interface IOptionBusiness
    {
        Task<IEnumerable<OptionList>> getAllOption();
        Task<OptionList?> getByIdOption(Int32 id);
        Task addOption(OptionSave options);
        Task updateOption(OptionSave options);
        Task updateState(Int32 id, Boolean state);
    }
}
