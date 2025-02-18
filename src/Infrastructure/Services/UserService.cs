using Domain.Entities.Identity;
using Domain.Services;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;

    public UserService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<AppUser> GetUserByIdAsync(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }

    public async Task<AppUser> GetUserByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<AppUser> GetUserByUserNameAsync(string userName)
    {
        return await _userManager.FindByNameAsync(userName);
    }

    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        return await Task.FromResult(_userManager.Users.ToList());
    }

    public async Task<AppUser> UpdateUserAsync(AppUser user)
    {
        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded)
            return user;

        throw new Exception($"Failed to update user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
    }

    public async Task<AppUser> DeleteUserAsync(AppUser user)
    {
        var result = await _userManager.DeleteAsync(user);
        if (result.Succeeded)
            return user;

        throw new Exception($"Failed to delete user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
    }

    public async Task<AppUser> CreateUserAsync(AppUser user, string password)
    {
        var result = await _userManager.CreateAsync(user, password);
        if (result.Succeeded)
            return user;

        throw new Exception($"Failed to create user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
    }

    public async Task<bool> CheckPasswordAsync(AppUser user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<string> ChangePasswordAsync(AppUser user, string password)
    {
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, token, password);

        if (result.Succeeded)
            return token;

        throw new Exception($"Failed to change password: {string.Join(", ", result.Errors.Select(e => e.Description))}");
    }
}
