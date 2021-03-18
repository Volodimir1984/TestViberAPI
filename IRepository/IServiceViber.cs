using System.Threading.Tasks;
using System.Collections.Generic;
using Model;

namespace IRepository
{
    public interface IServiceViber
    {
        Task SetWebHook();
        bool IsRegister();
        Task RemoveWebHook();
        Task AddUser(string data);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int Id);
        Task UpdateUser(int Id);
    }
}
