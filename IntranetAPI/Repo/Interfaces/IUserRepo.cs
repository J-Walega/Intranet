using IntranetAPI.Entities;
using System.Threading.Tasks;

namespace IntranetAPI.Repo.Interfaces
{
    public interface IUserRepo
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<bool> RegisterUserAsync(User user);
    }
}