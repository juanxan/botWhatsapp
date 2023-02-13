using AutoMapper;
using botWhatsapp.Application.Abstractions.Interface;
using botWhatsapp.Application.Business.Base;
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
    public class MessagesBusiness : BusinessBase<BotWhatsappError>, IMessagesBusiness
    {
        private readonly IMessageRepository _repository;
        private readonly IMapper _mapper;

        public MessagesBusiness(BusinessInitializer<BotWhatsappError> serviceInitializer,
            ILogger<MessagesBusiness> logger,
            IMessageRepository messagesRepository,
            IMapper mapper) : base(serviceInitializer, logger)
        {
            _repository = messagesRepository;
            _mapper = mapper;
        }

        async Task IMessagesBusiness.AddMessage(MessageSave messages)
            => await this._repository.addMessage(this._mapper.Map<Message>(messages));

        async Task<IEnumerable<MessageSave>> IMessagesBusiness.GetAllMessage()
            => base.ValidateOutputEnumerable<MessageSave>(this._mapper.Map<IEnumerable<MessageSave>>(await this._repository.getAllMessage()));
         
        async Task<MessageSave> IMessagesBusiness.GetByIdMessage(Int32 id)
        {
            Message? message = await this._repository.getByIdMessage(id);
            if(message is null)
                throw this.CreateException(BotWhatsappError.NullParameter, ErrorSource.Output);
            else
                return this._mapper.Map<MessageSave>(message);
        }
        async Task IMessagesBusiness.UpdateMessage(MessageSave messages)
            => await this._repository.updateMessage(this._mapper.Map<Message>(messages));

        async Task IMessagesBusiness.updateState(Int32 id, Boolean state)
            => await this._repository.updateState(id, state);
    }
}
