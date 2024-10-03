namespace Project.Domain.Entities
{
    public class UserDetail : BaseEntity
    {
        public string Fullname { get; private set; }
        public DateTime BirthDate  { get; private set; }
        public string Email { get; private set; }
        public string Bio { get; private set; }

        public long UserId { get; private set; }
        public virtual User User { get; private set; } = null!;

        public UserDetail(string fullname, DateTime birthDate, string email, string bio,  long userId)
        {
            Fullname = fullname;
            BirthDate = DateTime.SpecifyKind(birthDate, DateTimeKind.Utc);
            Email = email;
            Bio = bio;
            UserId = userId;
        }

        public void UpdateFullname(string fullname)
        {
            Fullname = fullname;
        }

        public void UpdateBirthDate(DateTime birthDate)
        {
            BirthDate = DateTime.SpecifyKind(birthDate, DateTimeKind.Utc);
        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }

        public void UpdateBio(string bio)
        {
            Bio = bio;
        }

    }
}
