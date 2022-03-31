using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Comment : Base
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string CommentText { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsDelete { get; set; }
        public int BlogID { get; set; }
        public Blog Blog { get; set; }
    }
}
