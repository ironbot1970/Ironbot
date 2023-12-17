using System;
using System.Collections.Generic;

#nullable disable

namespace irobotservice.Models
{
    public partial class Robot
    {
        public Robot()
        {
            Carts = new HashSet<Cart>();
            Rentals = new HashSet<Rental>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public string PhotoUrl { get; set; }
        public int CategoryId { get; set; }
        public string Manufacturer { get; set; }
        public int? ManufactureYear { get; set; }
        public decimal RentalFee { get; set; }
        public decimal Deposit { get; set; }
        public int Status { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
