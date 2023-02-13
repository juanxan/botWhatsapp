using AutoMapper;
using botWhatsapp.Application.Abstractions.Interface;
using botWhatsapp.Common.Enums;
using botWhatsapp.Common.TransferObjects;
using botWhatsapp.DataAccess.Abstractions.Entities;
using botWhatsapp.DataAccess.Abstractions.Interface;
using GT.Transversal;
using GT.Transversal.Enums;
using GT.Transversal.Objects;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace botWhatsapp.Application.Business
{
    public class OptionResponseBusiness : BusinessBase<BotWhatsappError>, IOptionResponseBusiness
    {
        private readonly IOptionResponseRepository _repository;
        private readonly IMapper _mapper;

        public OptionResponseBusiness(
            BusinessInitializer<BotWhatsappError> serviceInitializer,
            ILogger logger,
            IOptionResponseRepository optionRepository,
            IMapper mapper) : base(serviceInitializer, logger)
        {
            _repository= optionRepository;
            _mapper= mapper;
        }

        async Task<Int32> IOptionResponseBusiness.AddOptionResponse(OptionResponseAdd optionResponse)
            => await this._repository.AddOptionResponse(this._mapper.Map<OptionResponse>(optionResponse));

        async Task<IEnumerable<OptionResponseList>> IOptionResponseBusiness.GetAllOptionResponse()
            => base.ValidateOutputEnumerable<OptionResponseList>(this._mapper.Map<IEnumerable<OptionResponseList>>(await this._repository.GetAllOptionResponse()));

        async Task <OptionResponseList> IOptionResponseBusiness.GetOptionResponseById(Int32 id)
        {
            OptionResponse optionResponseDb = await this._repository.GetOptionResponseById(id);
            if(optionResponseDb is null)
                throw this.CreateException(BotWhatsappError.NullParameter, ErrorSource.Output);
            else
                return this._mapper.Map<OptionResponseList>(optionResponseDb);
        }
    }
}
