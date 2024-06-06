namespace ApiWebTwitter.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public List<Publication> Publications {  get; set; }
        public List<Followed> Followeds { get; set; }

        public User(string name,string nickname)
        {
            Name = name;
            NickName = nickname;
            Publications = new List<Publication>();
            Followeds = new List<Followed>();
        }

    }
}
