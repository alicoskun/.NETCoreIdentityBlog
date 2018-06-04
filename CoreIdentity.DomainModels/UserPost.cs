using CoreIdentity.DomainModels.Identity;

namespace CoreIdentity.DomainModels
{
    public class UserPost
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
