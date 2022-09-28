using System.ComponentModel.DataAnnotations;

namespace PersonRegisterTest.Infrastracture.Entities
{
    public class UserTitle
    {
        public UserTitle()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
