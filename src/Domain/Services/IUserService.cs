using Domain.Entities.Identity;

namespace Domain.Services;
public interface IUserService
{
    public Task<AppUser> GetUserByIdAsync(string userId);
    public Task<AppUser> GetUserByEmailAsync(string email);
    public Task<AppUser> GetUserByUserNameAsync(string userName);
    public Task<IEnumerable<AppUser>> GetUsersAsync();
    public Task<AppUser> UpdateUserAsync(AppUser user);
    public Task<AppUser> DeleteUserAsync(AppUser user);
    public Task<AppUser> CreateUserAsync(AppUser user, string password);
    public Task<bool> CheckPasswordAsync(AppUser user, string password);
    public Task<string> ChangePasswordAsync(AppUser user, string password);
}