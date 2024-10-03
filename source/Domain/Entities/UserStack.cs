
namespace Project.Domain.Entities
{
    public class UserStack : BaseEntity
    {
        public long UserId { get; private set; }
        public virtual User User { get; private set; } = null!;
        
        public long StackId { get; private set; }
        public virtual Stack Stack { get; private set; } = null!;
        
        public UserStack(long stackId, long userId)
        {
            StackId = stackId;
            UserId = userId;
        }
    }
}
