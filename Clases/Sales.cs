using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Sales
    {
        public int SaleId { get; set; }

        public int ReservationId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime SaleDate { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal Tax { get; set; }

        public decimal Tip { get; set; }

        public string? PaymentMethod { get; set; }

        public string? Notes { get; set; }

        public SaleDetails SaleDetails { get; set; }
    }
}
