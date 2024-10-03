namespace Project.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public long TeamId { get; private set; }
        public virtual Team Team { get; private set; } = null!;
        public virtual UserDetail UserDetail { get; private set; } = null!;
        public virtual ICollection<UserStack> UserStacks { get; set; } = [];

        public User(string login, string password, long teamId)
        {
            Login = login;
            Password = password;
            TeamId = teamId;
        }

        public void UpdateLogin(string login)
        {
            Login = login;
        }

        public void UpdateTeamId(long teamId)
        {
            TeamId = teamId;
        }


    }
}
