using botWhatsapp.Application.Abstractions.Interface;
using botWhatsapp.Common.TransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace botWhatsapp.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly IOptionBusiness _business;

        public OptionController(IOptionBusiness business)
        {
            _business = business;
        }
        [HttpGet("getAllOption")]
        public async Task<IEnumerable<OptionList>> getAll()
            => await this._business.getAllOption();
        [HttpGet("getOptionById/{id}")]
        public async Task<OptionList> getById(Int32 id)
            => await this._business.getByIdOption(id);

        [HttpPost("addOption")]
        public async Task addOption(OptionSave option)
            => await this._business.addOption(option);

        [HttpPut("updateState/{id}/{state}")]
        public async Task updateState(Int32 id, Boolean state)
            => await _business.updateState(id, state);

        [HttpPatch("updateOption")]
        public async Task updateOption(OptionSave option)
            => await this._business.updateOption(option);
    }
}
