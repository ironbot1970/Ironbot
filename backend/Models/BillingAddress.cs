using System;
using System.Collections.Generic;

#nullable disable

namespace irobotservice.Models
{
    public partial class BillingAddress
    {
        public BillingAddress()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Vatnumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Address { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
