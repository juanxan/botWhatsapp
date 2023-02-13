using botWhatsapp.DataAccess.Abstractions.Entities;


namespace botWhatsapp.DataAccess.Abstractions.Interface
{
    public interface IOptionResponseRepository
    {
        Task<Int32> AddOptionResponse(OptionResponse optionResponse);
        Task<IEnumerable<OptionResponse>> GetAllOptionResponse();
        Task<OptionResponse> GetOptionResponseById(Int32 id);
    }
}
