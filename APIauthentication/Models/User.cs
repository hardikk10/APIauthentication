namespace AuthenticationAPI.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public static class UserRepository
    {
        public static List<User> Users = new List<User>
    {
        new User { Username = "player1", Password = "password1", Role = "player" },
        new User { Username = "admin1", Password = "password2", Role = "admin" },
        new User { Username = "vipUser1", Password = "password3", Role = "vip_player" }
    };

        public static User ValidateUser(string username, string password)
        {
            return Users.SingleOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
