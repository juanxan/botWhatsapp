using botWhatsapp.Application.Abstractions.Interface;
using botWhatsapp.Common.TransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace botWhatsapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        private readonly IResponseBusiness _business;

        public ResponseController(IResponseBusiness business)
        {
            _business = business;
        }

        [HttpGet("getAll")]
        public async Task<IEnumerable<ResponseList>> getAllResponse()
            => await this._business.getAllResponse();

        [HttpGet("getById/{id}")]
        public async Task<ResponseList?> getByIdResponse(Int32 id)
            => await this._business.getByIdResponse(id);

        [HttpPost("addResponse")]
        public async Task addResponse(ResponseSave responses)
        => await this._business.addResponse(responses);

        [HttpPut("updateState/{id}/{state}")]
        public async Task updateState(Int32 id, Boolean state)
        => await this._business.updateState(id, state);

        [HttpPatch("updateResponse")]
        public async Task UpdateResponse(ResponseSave responses)
        => await this._business.UpdateResponse(responses);
    }
}
