using Microsoft.EntityFrameworkCore;
using PersonRegisterTest.Infrastracture.Entities;

namespace PersonRegisterTest.Infrastracture.Repository
{

    public class UserRepo : IUserRepo
    {
        private readonly UserContext _ctx;

        public UserRepo(UserContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<User> CreateUser(User user)
        {
            await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(User userForDelete)
        {
            userForDelete.IsActive = false;
            await UpdateUser(userForDelete);
        }

        public async Task<User> GetSignleUser(int id)
        {
            return await _ctx.Users.Include(x => x.UserTitle).Include(x => x.UserType).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _ctx.Users.Include(x => x.UserTitle).Include(x => x.UserType).Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            _ctx.Users.Update(user);
            await _ctx.SaveChangesAsync();
            return user;
        }
    }
}
