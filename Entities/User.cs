namespace Site_EKMTech_API2.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
