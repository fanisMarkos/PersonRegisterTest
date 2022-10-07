using Microsoft.EntityFrameworkCore;

namespace PersonRegisterTest.Infrastracture.Entities
{
    public class UserContext : DbContext
    {
        public UserContext() // For Unit Testing Only
        {

        }

        public UserContext(DbContextOptions<UserContext> opts) : base(opts) 
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserTitle> UserTitles { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
    }
}
