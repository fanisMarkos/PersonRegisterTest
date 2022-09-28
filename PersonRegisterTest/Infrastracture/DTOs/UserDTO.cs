namespace PersonRegisterTest.Infrastracture.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        public int UserTypeId { get; set; }

        public int UserTitleId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }

        public DateTime? BirthDate { get; set; }

        public string TitleDescription { get; set; }

        public string TypeDescription { get; set; }

        public string TypeCode { get; set; }

        public bool? IsActive { get; set; }
    }
}
