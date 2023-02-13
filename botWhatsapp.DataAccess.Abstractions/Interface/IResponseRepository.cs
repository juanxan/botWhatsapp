using botWhatsapp.Entities;

namespace botWhatsapp.DataAccess.Abstractions.Interface
{
    public interface IResponseRepository
    {
        Task<IEnumerable<Response>> getAllResponse();
        Task<Response?> getByIdResponse(Int32 id);
        Task addResponse(Response responses);
        Task updateState(Int32 id, Boolean state);
        Task UpdateResponse(Response responses);
        Task<Response> WelcomeMessage();
    }
}
