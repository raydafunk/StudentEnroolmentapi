using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.data
{
    public class SchoolUser : IdentityUser
    {
        public  string FristName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBrith { get; set; }
    }
}
