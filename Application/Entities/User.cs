namespace SuplementShop.Application.Entities
{
    public class User : Entity
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public static User Create(int id, string email, string name, string password, Role role)
        {
            return new User
            {
                Id = id,
                Email = email,
                FullName = name,
                Password = password,
                Role = role
            };
        }
    }
}
