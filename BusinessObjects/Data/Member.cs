using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BusinessObjects.Data
{
    public class Member : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
