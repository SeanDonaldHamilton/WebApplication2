using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarahsArtworksBlog.Models
{
    public class ArtworkPost
    {
        public ArtworkPost()
        {
            Comments = new List<Comment>();
        }
        public DateTime date { get; set; }
        public string text { get; set; }
        public string image { get; set; }
        //public string PostID { get; set; }
        public int ArtworkPostID { get; set; }
        public string Name { get; set; }
        //public string CommentID { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }

    //class Comments
    public class Comment
    {
        public int CommentID { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public string text { set; get; }
        //public int PostID { get; set; }
        public int ArtworkPostID { get; set; }

        public virtual ArtworkPost ArtworkPost { get; set; }

    }
    class ArtworkBlogDbContext : DbContext
    {
        public ArtworkBlogDbContext() : base("name=ArtworkBlogDbConnection")
        {
        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ArtworkPost> ArtworkPosts { get; set; }
    }

}



