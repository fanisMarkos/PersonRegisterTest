using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonRegisterTest.Infrastracture.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool? IsActive { get; set; }

        public int UserTypeId { get; set; }

        public int UserTitleId { get; set; }

        public UserType UserType { get; set; }

        public UserTitle UserTitle { get; set; }


    }
}
