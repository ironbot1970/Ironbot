using System;
using System.Collections.Generic;

#nullable disable

namespace irobotservice.Models
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
            Rentals = new HashSet<Rental>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Address { get; set; }
        public int? BillingAddressId { get; set; }
        public int Status { get; set; }
        public ulong IsValidated { get; set; }
        public string ValidationUrl { get; set; }
        public ulong IsAdmin { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual BillingAddress BillingAddress { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
