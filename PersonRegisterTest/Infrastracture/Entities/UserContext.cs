using Microsoft.EntityFrameworkCore;

namespace PersonRegisterTest.Infrastracture.Entities
{
    public class UserContext : DbContext
    {

        public UserContext(DbContextOptions<UserContext> opts) : base(opts) 
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserTitle> UserTitles { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
    }
}
