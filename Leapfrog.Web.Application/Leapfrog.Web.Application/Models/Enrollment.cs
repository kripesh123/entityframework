using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leapfrog.Web.Application.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        public double? Discount { get; set; }
        public DateTime EnrolledDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Status { get; set; }

        public IEnumerable<Payment> Payments { get; set; }
    }
}