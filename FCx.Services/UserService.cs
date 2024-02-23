using FCx.Domain.Entities;
using FCx.Domain.Interfaces;

namespace FCx.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(Pager pager)
        {
            return await _userRepository.GetAllAsync(pager);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> AddAsync(User user)
        {
            return await _userRepository.AddAsync(user);
        }

        public async Task<User> UpdateAsync(User user)
        {
            return await _userRepository.UpdateAsync(user);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task DeleteSelectedAsync(int[] userIds)
        {
            await _userRepository.DeleteSelectedAsync(userIds);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.GetUserByUsernameAsync(username);
        }   
        public async Task<User> GetUserByDataAsync(ResetPasswordRequest resetPasswordRequest)
        {
            return await _userRepository.GetUserByDataAsync(resetPasswordRequest);
        }
        public async Task UpdatePasswordAsync(LoginRequest loginRequest)
        {
            await _userRepository.UpdatePasswordAsync(loginRequest);
        }

    }
}
