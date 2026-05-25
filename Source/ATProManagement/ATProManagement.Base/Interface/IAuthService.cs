using ATProManagement.Db.Entity;
using Microsoft.AspNetCore.Identity;

namespace ATProManagement.Base
{
    public interface IAuthService
    {
        string GenerateToken(EntityUser entity);
        Task<string?> Login(string email, string password);
        Task Logout();
        Task<IdentityResult> CreateUser(CreateUserDto dto);
    }
}
