using Leapfrog.Web.Application.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Leapfrog.Web.Application.Context
{
    public class LeapfrogDbContext : DbContext
    {
        public LeapfrogDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Facilitator> Facilitators { get; set; }
    }
}