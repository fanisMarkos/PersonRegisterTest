using PersonRegisterTest.Infrastracture.DTOs;
using PersonRegisterTest.Infrastracture.Entities;

namespace PersonRegisterTest.Infrastracture.Services
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetUsersListAsync();

        Task<UserCreateEditDto> GetUserByIdAsync(int id);

        Task<User> CreateUserAsync(UserCreateEditDto model);

        Task<User> UpdateUserAsync(int id,UserCreateEditDto model);

        Task DeleteUserAsync(int id);

        Task<List<UserTitle>> GetUserTittlesSync();

        Task<List<UserType>> GetUserTypesAsync();
    }
}
