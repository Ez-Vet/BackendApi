

using EzvetApi.IAM.domain.Model.Commands;

namespace EzvetApi.IAM.domain.Model.Aggregates
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }


        public User()
        {
            Name = string.Empty;
            Email = string.Empty;
            Password = string.Empty;

        }

        public User(SignInCommand command)
        {
            Email = command.Email;
            Password = command.Password;
        }

        public User(SignUpCommand command)
        {
            Name = command.Name;
            Email = command.Email;
            Password = command.Password;

        }
    }
}