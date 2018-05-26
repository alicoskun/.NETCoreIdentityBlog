using CoreIdentity.Models.Identity;

namespace CoreIdentity.Models
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
