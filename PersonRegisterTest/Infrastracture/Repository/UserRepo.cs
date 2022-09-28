using Microsoft.EntityFrameworkCore;
using PersonRegisterTest.Infrastracture.Entities;

namespace PersonRegisterTest.Infrastracture.Repository
{
    public interface IUserRepo
    {
        Task<List<User>> GetUsers();

        Task<User> GetSignleUser(int id);

        Task<User> CreateUser(User user); 

        Task<User> UpdateUser(User user);

        Task DeleteUser(int id);

    }

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

        public async Task DeleteUser(int id)
        {
            var userForDelete = await GetSignleUser(id);
            if(userForDelete!=null)
            {
                userForDelete.IsActive = false;
                await UpdateUser(userForDelete);
            }
        }

        public async Task<User> GetSignleUser(int id)
        {
            return await _ctx.Users.Include(x => x.UserTitle).Include(x => x.UserType).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _ctx.Users.Include(x => x.UserTitle).Include(x => x.UserType).Where(x=>x.IsActive==true).ToListAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            _ctx.Entry(user).State = EntityState.Modified;
            _ctx.Entry(user.UserTitle).State= EntityState.Modified;
            _ctx.Entry(user.UserType).State=EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return user;
        }
    }
}
