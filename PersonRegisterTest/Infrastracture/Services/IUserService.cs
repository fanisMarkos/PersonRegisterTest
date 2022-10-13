using PersonRegisterTest.Infrastracture.DTOs;
using PersonRegisterTest.Infrastracture.Entities;

namespace PersonRegisterTest.Infrastracture.Services
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetUsersListAsync();

        Task<UserDTO> GetUserByIdAsync(int id);

        Task<User> CreateUserAsync(UserDTO model);

        Task<User> UpdateUserAsync(int id,UserDTO model);

        Task DeleteUserAsync(int id);
    }
}
