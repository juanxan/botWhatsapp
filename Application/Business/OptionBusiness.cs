using AutoMapper;
using botWhatsapp.Application.Abstractions.Interface;
using botWhatsapp.Common.Enums;
using botWhatsapp.Common.TransferObjects;
using botWhatsapp.DataAccess.Abstractions.Interface;
using botWhatsapp.Entities;
using GT.Transversal.Objects;
using Microsoft.Extensions.Logging;
using GT.Transversal;
using GT.Transversal.Enums;

namespace botWhatsapp.Application.Business
{
    public class OptionBusiness : BusinessBase<BotWhatsappError>, IOptionBusiness
    {
        private readonly IOptionRepository _repository;
        private readonly IMapper _mapper;

        public OptionBusiness(BusinessInitializer<BotWhatsappError> serviceInitializer,
           ILogger<OptionBusiness> logger,
           IOptionRepository optionRepository,
           IMapper mapper) : base(serviceInitializer, logger)
        {
            _repository = optionRepository;
            _mapper = mapper;
        }
        async Task IOptionBusiness.addOption(OptionSave options)
        {
            await this._repository.addOption(this._mapper.Map<Option>(options));
        }

        async Task<IEnumerable<OptionList>> IOptionBusiness.getAllOption()
            => base.ValidateOutputEnumerable<OptionList>(this._mapper.Map<IEnumerable<OptionList>>(await this._repository.getAllOption()));


        async Task<OptionList?> IOptionBusiness.getByIdOption(Int32 id)
        {
            Option? options = await this._repository.getByIdOption(id);
            if(options is null)
                throw this.CreateException(BotWhatsappError.NullParameter, ErrorSource.Output);
            else
                return this._mapper.Map<OptionList>(options);
        }

        async Task IOptionBusiness.updateOption(OptionSave options)
            => await this._repository.updateOption(this._mapper.Map<Option>(options));

        async Task IOptionBusiness.updateState(Int32 id, bool state)
            => await this._repository.updateState(id, state);
    }
}
