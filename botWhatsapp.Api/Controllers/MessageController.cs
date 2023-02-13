using botWhatsapp.Application.Abstractions.Interface;
using botWhatsapp.Common.TransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace botWhatsapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessagesBusiness _business;

        public MessageController(IMessagesBusiness business)
        {
            _business = business;
        }
      
        [HttpGet("getAllMessage")]
        public async Task<IEnumerable<MessageSave>> getAll()
            =>  await this._business.GetAllMessage();

        [HttpGet("getById/{id}")]
        public async Task <MessageSave> GetByIdMessage(Int32 id)
            => await this._business.GetByIdMessage(id);

        [HttpPost("addMessage")]
        public async Task AddAsync(MessageSave message)
          => await this._business.AddMessage(message);

        [HttpPatch("updateMessage")]
        public async Task updateMessage(MessageSave message)
            => await this._business.UpdateMessage(message);

        [HttpPut("updateState/{id}/{state}")]
        public async Task updateState(Int32 id, Boolean state)
            => await this._business.updateState(id, state);
    }
}
