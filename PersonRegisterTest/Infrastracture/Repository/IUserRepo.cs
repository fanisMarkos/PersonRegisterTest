using PersonRegisterTest.Infrastracture.Entities;

namespace PersonRegisterTest.Infrastracture.Repository
{
    public interface IUserRepo
    {
        Task<List<User>> GetUsers();

        Task<User> GetSignleUser(int id);

        Task<User> CreateUser(User user); 

        Task<User> UpdateUser(User user);

        Task DeleteUser(User userForDelete);

        Task<List<UserTitle>> GetUserTitles();

        Task<List<UserType>> GetUserTypes();

    }
}
