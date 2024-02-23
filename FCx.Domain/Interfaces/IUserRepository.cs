using FCx.Domain.Entities;

namespace FCx.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync(Pager pager);
        Task<User> GetByIdAsync(int id);
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<int> DeleteAsync(int id);
        Task DeleteSelectedAsync(int[] userIds);
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> GetUserByDataAsync(ResetPasswordRequest resetPasswordRequest);
        Task UpdatePasswordAsync(LoginRequest loginRequest);
    }
}
