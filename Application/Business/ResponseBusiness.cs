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
    public class ResponseBusiness : BusinessBase<BotWhatsappError>, IResponseBusiness
    {
        public readonly IResponseRepository _repository;
        public readonly IMapper _mapper;

        public ResponseBusiness(BusinessInitializer<BotWhatsappError> serviceInitializer,
            ILogger<ResponseBusiness> logger,
            IResponseRepository repository,
            IMapper mapper) : base(serviceInitializer, logger)
        {
            _repository = repository;
            _mapper = mapper;
        }

        async Task IResponseBusiness.addResponse(ResponseSave responses)
            => await this._repository.addResponse(this._mapper.Map<Response>(responses));


        async Task<IEnumerable<ResponseList>> IResponseBusiness.getAllResponse()
            => base.ValidateOutputEnumerable<ResponseList>(this._mapper.Map<IEnumerable<ResponseList>>(await this._repository.getAllResponse()));

        async Task<ResponseList?> IResponseBusiness.getByIdResponse(Int32 id)
        {
            Response? response = await this._repository.getByIdResponse(id);
            if(response is null)
                throw this.CreateException(BotWhatsappError.NullParameter, ErrorSource.Output);
            else
                return this._mapper.Map<ResponseList>(response);
        }

        async Task IResponseBusiness.UpdateResponse(ResponseSave responses)
            => await this._repository.UpdateResponse(this._mapper.Map<Response>(responses));  


        async Task IResponseBusiness.updateState(Int32 id, bool state)
            => await this._repository.updateState(id, state);
    }
}
