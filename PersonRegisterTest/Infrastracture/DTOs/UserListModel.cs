namespace PersonRegisterTest.Infrastracture.DTOs
{
    public class UserListModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }

        public DateTime BirthDate { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string Code { get; set; }

        public bool? IsActive { get; set; }
    }
}
