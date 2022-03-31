using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Blog : Base
    {
        [DisplayName("Basliq")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoURL { get; set; }
        public int Hit { get; set; }
        public string SeoURL { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public string K205UserId { get; set; }
        public K205User K205User { get; set; }
    }
}
