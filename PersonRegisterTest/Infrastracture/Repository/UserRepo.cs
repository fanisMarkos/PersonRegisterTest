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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> CreateUser(User user)
        {
            await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();
            return user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userForDelete"></param>
        /// <returns></returns>
        public async Task DeleteUser(User userForDelete)
        {
            userForDelete.IsActive = false;
            await UpdateUser(userForDelete);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> GetSignleUser(int id)
        {
            return await _ctx.Users.Include(x => x.UserTitle).Include(x => x.UserType).FirstOrDefaultAsync(x => x.Id == id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>List<User></returns>
        public async Task<List<User>> GetUsers()
        {
            return await _ctx.Users.Include(x => x.UserTitle).Include(x => x.UserType).Where(x => x.IsActive == true).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> UpdateUser(User user)
        {
            _ctx.Users.Update(user);
            await _ctx.SaveChangesAsync();
            return user;
        }
    }
}
