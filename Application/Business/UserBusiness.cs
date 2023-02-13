

using AutoMapper;
using botWhatsapp.Application.Abstractions.Interface;
using botWhatsapp.Common.Enums;
using botWhatsapp.Common.TransferObjects;
using botWhatsapp.DataAccess.Abstractions.Interface;
using botWhatsapp.Entities;
using GT.Transversal;
using GT.Transversal.Enums;
using GT.Transversal.Objects;
using Microsoft.Extensions.Logging;

namespace botWhatsapp.Application.Business
{
    public class UserBusiness : BusinessBase<BotWhatsappError>, IUserBusiness
    {
        public readonly IUserRepository _repository;
        public readonly IMapper _mapper;

        public UserBusiness(BusinessInitializer<BotWhatsappError> serviceInitializer,
            ILogger<UserBusiness> logger,
            IUserRepository repository,
            IMapper mapper): base(serviceInitializer, logger)
        {
            _repository = repository;
            _mapper = mapper;
        }

        async Task<Int32> IUserBusiness.addUser(UserSave Users)
            => await this._repository.addUser(this._mapper.Map<User>(Users));

        async Task<IEnumerable<UserList>> IUserBusiness.getAllUser()
            => base.ValidateOutputEnumerable<UserList>(this._mapper.Map<IEnumerable<UserList>>(await this._repository.getAllUser()));



        async Task<UserList> IUserBusiness.getByIdUser(Int32 id)
        {
           User? user = await this._repository.getByIdUser(id);
            if(user is null)
                throw this.CreateException(BotWhatsappError.NullParameter, ErrorSource.Output);
            else
                return  this._mapper.Map<UserList>(user);
        }

        async Task IUserBusiness.updateUser(UserSave user)
            => await this._repository.updateUser(this._mapper.Map<User>(user));

        Task IUserBusiness.updateState(Int32 id, Boolean state)
            => this._repository.updateState(id, state);
    }
}
