using System;
using System.Threading.Tasks;

namespace FEProject.Users
{
    public interface IUserAppService
    {
        Task<Guid> CreateUserAsync(CreateUserDto input);
        Task<string> LoginAsync(LoginDto input);
        Task ChangePasswordAsync(ChangePasswordDto input);
        Task ForgotPasswordAsync(string email);
        Task ResetPasswordAsync(ResetPwDto input);

    }
}
