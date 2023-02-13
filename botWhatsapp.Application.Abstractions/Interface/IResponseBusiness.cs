using botWhatsapp.Common.TransferObjects;

namespace botWhatsapp.Application.Abstractions.Interface
{
    public interface IResponseBusiness
    {
        Task<IEnumerable<ResponseList>> getAllResponse();
        Task<ResponseList?> getByIdResponse(Int32 id);
        Task addResponse(ResponseSave responses);
        Task updateState(Int32 id, Boolean state);
        Task UpdateResponse(ResponseSave responses);
    }
}
