using System;
using System.Collections.Generic;

#nullable disable

namespace irobotservice.Models
{
    public partial class Rental
    {
        public int Id { get; set; }
        public string RentalGroup { get; set; }
        public int UserId { get; set; }
        public int RobotId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RentalFee { get; set; }
        public decimal RentalDeposit { get; set; }
        public decimal RentalTotalAmount { get; set; }
        public ulong IsDepositPaid { get; set; }
        public ulong IsRentalTotalAmountPaid { get; set; }
        public ulong IsDepositRefunded { get; set; }
        public int Status { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual Robot Robot { get; set; }
        public virtual User User { get; set; }
    }
}
