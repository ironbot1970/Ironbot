using System;
using System.Collections.Generic;

#nullable disable

namespace irobotservice.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RobotId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual Robot Robot { get; set; }
        public virtual User User { get; set; }
    }
}
