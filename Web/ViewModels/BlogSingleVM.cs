using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewModels
{
    public class BlogSingleVM 
    {
        public Blog BlogSingle { get; set; }

        public List<Blog> Blogs { get; set; }

        public K205User User { get; set; }

        public List<Blog> Similar { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
