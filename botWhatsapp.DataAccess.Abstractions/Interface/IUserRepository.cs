using botWhatsapp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace botWhatsapp.DataAccess.Abstractions.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> getAllUser();
        Task<User> getByIdUser(Int32 id);
        Task<User> getUserByPhone(String phone);
        Task<Int32> addUser(User Users);
        Task updateUser(User Users);
        Task updateState(Int32 id, Boolean state);
    }
}
