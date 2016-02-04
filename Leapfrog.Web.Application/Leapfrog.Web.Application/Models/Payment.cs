using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leapfrog.Web.Application.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public Enrollment Enrollment { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Status { get; set; }
    }
}