using botWhatsapp.Common.TransferObjects;


namespace botWhatsapp.Application.Abstractions.Interface
{
    public interface IUserBusiness
    {
        Task<IEnumerable<UserList>> getAllUser();
        Task<UserList> getByIdUser(Int32 id);
        Task<Int32> addUser(UserSave Users);
        Task updateUser(UserSave Users);
        Task updateState(Int32 id, Boolean state);
    }
}
