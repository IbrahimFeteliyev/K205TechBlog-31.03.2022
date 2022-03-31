using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class K205User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhotoURL { get; set; }
        public string About { get; set; }

    }
}
