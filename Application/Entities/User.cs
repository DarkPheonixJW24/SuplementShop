namespace SuplementShop.Application.Entities
{
    public class User
    {
        public int Id { get; private set; }

        public string Email { get; private set; }

        public string FullName { get; private set; }

        public string Password { get; private set; }

        public Role Role { get; private set; }

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
