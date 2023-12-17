using System;
using System.Collections.Generic;

#nullable disable

namespace irobotservice.Models
{
    public partial class Category
    {
        public Category()
        {
            Robots = new HashSet<Robot>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ulong IsDeleted { get; set; }

        public virtual ICollection<Robot> Robots { get; set; }
    }
}
