using AutoMapper;
using botWhatsapp.Common.Enums;
using botWhatsapp.Common.TransferObjects;
using botWhatsapp.Common.TransferObjects.Base;
using botWhatsapp.Common.TransferObjects.Conversation;
using botWhatsapp.DataAccess.Abstractions.Interface;
using botWhatsapp.Entities;
using GT.Transversal;
using GT.Transversal.Objects;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace botWhatsapp.Application.Business.Base
{
    public class BaseBusiness : BusinessBase<BotWhatsappError>
    {
        public readonly IUserRepository _userRepository;
        public readonly IMessageRepository _messageRepository;
        public readonly IResponseRepository _responseRepository;
        public readonly IMapper _mapper;

        public BaseBusiness(BusinessInitializer<BotWhatsappError> serviceInitializer,
            ILogger<MessagesBusiness> logger,
            IUserRepository userRepository,
            IMessageRepository messageRepository,
            IResponseRepository responseRepository,
            IMapper mapper) : base(serviceInitializer, logger)
        {
            _userRepository = userRepository;
            _messageRepository = messageRepository;
            _responseRepository = responseRepository;
            _mapper = mapper;
        }

        protected async Task<UserBase> ProcessUser(UserSave user)
        {
            User? userDb = await this._userRepository.getUserByPhone(user.Phone);
            if (userDb is null)
            {
                return new()
                {
                    Id = await this._userRepository.addUser(this._mapper.Map<User>(user)),
                    exist = false
                };
            }
            else
            {
                return new()
                {
                    Id = userDb.Id,
                    exist = true
                };
            }
        }
        protected async Task<Int32> AddMessage(Int32 idConversation,Int32 MessageId)
            => await 
        protected async Task<ResponseList> WelcomeMessage()
            => this._mapper.Map<ResponseList>(await this._responseRepository.WelcomeMessage());
        protected async Task<MessageList> getMessageByIdConversationLast(Int32 idConversation)
            => this._mapper.Map<MessageList>(await this._messageRepository.getMessageByIdConversationLast(idConversation));
    }
}
