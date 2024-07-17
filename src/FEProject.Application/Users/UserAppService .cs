using FEProject.Emails;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;


namespace FEProject.Users
{
    public class UserAppService : ApplicationService, IUserAppService, ITransientDependency
    {
        private readonly IdentityUserManager _userManager;
        private readonly IEmailService _emailService;

        public UserAppService(IdentityUserManager userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<Guid> CreateUserAsync(CreateUserDto input)
        {
            var user = new IdentityUser(
                Guid.NewGuid(),
                input.UserName,
                input.Email);

            var result = await _userManager.CreateAsync(user, input.Password);

            if (result.Succeeded)
            {
                await CurrentUnitOfWork.SaveChangesAsync();
                return Guid.Parse(user.Id.ToString());
            }
            else
            {
                throw new ApplicationException($"Failed to create user: {string.Join(", ", result.Errors)}");
            }
        }

        public async Task<string> LoginAsync(LoginDto input)
        {
            var user = await _userManager.FindByNameAsync(input.UserNameOrEmail) ?? await _userManager.FindByEmailAsync(input.UserNameOrEmail);

            if (user == null)
            {
                throw new ApplicationException("Invalid username or email.");
            }

            var result = await _userManager.CheckPasswordAsync(user, input.Password);

            if (result)
            {
                // Generate JWT token or set cookies as per your authentication setup
                return "Login successful"; // Replace with actual token if using JWT
            }
            else
            {
                throw new ApplicationException("Invalid password.");
            }
        }


        public async Task ChangePasswordAsync(ChangePasswordDto input)
        {
            var user = await _userManager.FindByIdAsync(input.UserId.ToString());
            if (user == null)
            {
                throw new ApplicationException("User not found.");
            }

            var result = await _userManager.ChangePasswordAsync(user, input.CurrentPassword, input.NewPassword);

            if (!result.Succeeded)
            {
                throw new ApplicationException($"Failed to change password: {string.Join(", ", result.Errors)}");
            }

            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task ForgotPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new ApplicationException("User not found.");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Send the token to the user's email
            await _emailService.SendEmailAsync(
                email,
                "Reset your password",
                $"Your password reset token is: {token}"
            );
        }

        public async Task ResetPasswordAsync(ResetPwDto input)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);
            if (user == null)
            {
                throw new ApplicationException("User not found.");
            }

            var result = await _userManager.ResetPasswordAsync(user, input.Token, input.NewPassword);

            if (!result.Succeeded)
            {
                throw new ApplicationException($"Failed to reset password: {string.Join(", ", result.Errors)}");
            }

            await CurrentUnitOfWork.SaveChangesAsync();
        }
    }
}
