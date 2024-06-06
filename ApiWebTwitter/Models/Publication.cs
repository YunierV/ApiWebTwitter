using System.Globalization;

namespace ApiWebTwitter.Models
{
    public class Publication
    {
        public int Id { get; set; }
        public User Author { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public Publication(User author, string content)
        {
            Author = author;
            Content = content;
            CreatedDate = DateTime.Now;
        }
    }
}