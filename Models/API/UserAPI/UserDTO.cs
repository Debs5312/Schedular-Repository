namespace Models.API.UserAPI
{
    public class UserDTO
    {
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public List<string> Role { get; set; }
        public bool ActiveStatus { get; set; }        
    }
}