namespace ApiWebTwitter.Models
{
    public class Followed
    {
        public User UserFollower { get; set; }
        public User UserFollowed { get; set; }

        public Followed(User userFollower, User userFollowed)
        {
            UserFollower = userFollower;
            UserFollowed = userFollowed;
        }
    }
}