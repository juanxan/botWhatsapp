using AutoMapper;
using botWhatsapp.Application.Abstractions.Interface;
using botWhatsapp.Application.Business.Base;
using botWhatsapp.Common.Enums;
using botWhatsapp.Common.TransferObjects;
using botWhatsapp.Common.TransferObjects.Conversation;
using botWhatsapp.DataAccess.Abstractions.Interface;
using botWhatsapp.Entities;
using GT.Transversal.Enums;
using GT.Transversal.Objects;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace botWhatsapp.Application.Business
{
    public class ConversationBusiness : BaseBusiness, IConversationBusiness
    {
        public IConversationRepository _repository;

        public ConversationBusiness(BusinessInitializer<BotWhatsappError> serviceInitializer,
            ILogger<MessagesBusiness> logger,
            IUserRepository userRepository,
            IMessageRepository messageRepository,
            IResponseRepository responseRepository,
            IConversationRepository conversationRepository,
            IMapper mapper) : base(serviceInitializer, logger, userRepository, messageRepository, responseRepository, mapper)
        {
            _repository = conversationRepository;
        }

        async Task<Int32> IConversationBusiness.addConversation(ConversationSave conversation)
            => await this.AddConversations(conversation);
       


        async Task<IEnumerable<ConversationList>> IConversationBusiness.GetAll()
            => base.ValidateOutputEnumerable<ConversationList>(this._mapper.Map<IEnumerable<ConversationList>>(await this._repository.GetAll()));

        async Task<ConversationList> IConversationBusiness.GetConversationById(Int32 id)
        {
            Conversation? conversation = await this._repository.GetConversationById(id);
            if(conversation is null)
                throw this.CreateException(BotWhatsappError.NullParameter, ErrorSource.Output);
            else
                return this._mapper.Map<ConversationList>(conversation);
        }

        async Task<Boolean> IConversationBusiness.updateConversation(ConversationSave conversation)
            => await this._repository.updateConversation(this._mapper.Map<Conversation>(conversation));

        async Task<Boolean> IConversationBusiness.updateState(int id, bool state)
            => await this._repository.updateState(id, state);
        async Task<ResponseList> IConversationBusiness.Conversation(Init init)
        {
            UserBase userBase = await base.ProcessUser(init.User);
            ConversationSave conversation = new ConversationSave();
            conversation.UserId = userBase.Id;
            conversation.State = true;
            if (!userBase.exist)
            {
                return await this.WelcomeMessage(conversation);
            }
            else
            {
                ConversationHasExpired expired = await this.ProcessConversations(conversation);
                if (expired.IsExpired)
                {
                    return await this.WelcomeMessage(conversation);
                }
                MessageList message = await base.getMessageByIdConversationLast(expired.Id);
                await this.ProccesResponse(init.Message, message.Reponse);
            }
        }
        private async Task<ConversationHasExpired> ProcessConversations(ConversationSave conversation)
        {
            Int32? conversationId = await this._repository.HasExpired(conversation.UserId);
            if (conversation is null)
            {
                conversationId = await this.AddConversations(conversation);
                return new()
                {
                    Id = conversationId.Value,
                    IsExpired = true
                };
            }
            return new(){
                Id = conversationId.Value,
                IsExpired = false
            };
        }
        private async Task<Int32> AddConversations(ConversationSave conversation)
            => await this._repository.addConversation(this._mapper.Map<Conversation>(conversation));
        private async Task<ResponseList> WelcomeMessage(ConversationSave conversation)
        {
            ResponseList welcome = await base.WelcomeMessage();
            await base.AddMessage(await this.AddConversations(conversation), welcome.Id);
            return welcome;
        }
        private async Task<OptionList?> ProccesResponse(MessageSave message, ResponseList response)
        {
            ResponseList options = response.Options.Select(x => x.Order);
            Int32? messageResponse = Int32.Parse(message.Reponse);
            if(messageResponse is null)
                throw this.CreateException(BotWhatsappError.NullParameter, ErrorSource.Input);
            OptionList? res = response.Options.Where(x => x.Order.Equals(messageResponse.Value)).FirstOrDefault();
            if(res is null)
                throw this.CreateException(BotWhatsappError.NullParameter, ErrorSource.Input);
            return res;
        }
    }
}
