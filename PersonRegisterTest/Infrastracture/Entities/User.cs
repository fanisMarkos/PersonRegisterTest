using System.ComponentModel.DataAnnotations;

namespace PersonRegisterTest.Infrastracture.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }

        public DateTime BirthDate { get; set; }

        public bool? IsActive { get; set; }

        public int UserTypeId { get; set; }

        public int UserTitleId { get; set; }

        public UserType UserType { get; set; }

        public UserTitle UserTitle { get; set; }


    }
}
