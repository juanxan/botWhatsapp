using botWhatsapp.Application.Abstractions.Interface;
using botWhatsapp.Common.TransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace botWhatsapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _business;

        public UserController(IUserBusiness business)
        {
            _business = business;
        }
        [HttpGet("getAll")]
        public async Task<IEnumerable<UserList>> GetAll()
            =>  await this._business.getAllUser();

        [HttpGet("getById/{id}")]
        public async Task getById(Int32 id)
            => await this._business.getByIdUser(id);

        [HttpPost("addUser")]
        public async Task addUser(UserSave user)
            => this._business.addUser(user);

        [HttpPatch("updateUser")]
        public async Task updateUser(UserSave user)
            => await this._business.updateUser(user);

        [HttpPut("UpdateState/{id}/{state}")]
        public async Task UpdateState(Int32 id, Boolean state)
            => await this._business.updateState(id, state);

    }
}
