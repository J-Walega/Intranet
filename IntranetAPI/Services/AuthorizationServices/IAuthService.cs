using IntranetAPI.Contracts.V1.Requests.Auth;
using IntranetAPI.Contracts.V1.Responses.Auth;
using System.Threading.Tasks;

namespace IntranetAPI.Services.AuthorizationServices
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<RegisterResponse> Register(RegisterRequest request);
    }
}
