namespace Project.Domain.Entities
{
    public class Stack : BaseEntity
    {
        public string StackName { get; private set; }
        public virtual ICollection<UserStack> UserStacks { get; set; } = [];

        public Stack(string stackName)
        {
            StackName = stackName;
        }

        public Stack(long id, string stackName)
        {
            Id = id;
            StackName = stackName;
        }

        public void UpdateStackName(string stackName)
        {
            StackName = stackName;
        }

    }
}
