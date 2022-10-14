namespace PersonRegisterTest.Infrastracture.DTOs
{
    public class UserCreateEditDto
    {
        public int Id { get; set; }

        public int UserTypeId { get; set; }

        public int UserTitleId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool? IsActive { get; set; }
    }
}
