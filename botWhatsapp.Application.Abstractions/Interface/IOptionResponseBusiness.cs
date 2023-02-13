using botWhatsapp.Common.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace botWhatsapp.Application.Abstractions.Interface
{
    public interface IOptionResponseBusiness
    {
        Task<Int32> AddOptionResponse(OptionResponseAdd optionResponse);
        Task<IEnumerable<OptionResponseList>> GetAllOptionResponse();
        Task<OptionResponseList> GetOptionResponseById(Int32 id);
    }
}
