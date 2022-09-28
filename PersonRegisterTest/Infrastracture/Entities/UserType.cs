using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonRegisterTest.Infrastracture.Entities
{
    [Table("UserType")]
    public class UserType
    {
        public UserType()
        {
            Users = new HashSet<User>();    
        }

        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
        [MaxLength(2)]
        public string Code { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
