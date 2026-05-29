using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IUserService
    {
        bool Register(string username, string password);
        bool ValidateCredentials(string username, string password);
    }
}
