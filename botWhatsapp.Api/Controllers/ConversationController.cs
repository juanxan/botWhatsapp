using botWhatsapp.Application.Abstractions.Interface;
using botWhatsapp.Common.TransferObjects;
using botWhatsapp.Common.TransferObjects.Base;
using Microsoft.AspNetCore.Mvc;

namespace botWhatsapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly IConversationBusiness _business;

        public ConversationController(IConversationBusiness business)
        {
            _business = business;
        }

        [HttpPost("Init")]
        async Task init(Init init)
            => await => this._business.Init(init);
    }
}
