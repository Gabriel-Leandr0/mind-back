namespace Project.Domain.Entities
{
    public class Team : BaseEntity
    {
        public string TeamName { get; private set; }
        public virtual ICollection<User> Members { get; set; } = [];

        public Team(string teamName)
        {
            TeamName = teamName;
        }

        public Team(long id, string teamName)
        {
            Id = id;
            TeamName = teamName;
        }

        public void UpdateTeamName(string teamName)
        {
            TeamName = teamName;
        }
    }
}
