using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonRegisterTest.Infrastracture.Entities
{
    [Table("UserTitle")]
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
