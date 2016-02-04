namespace Leapfrog.Web.Application.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Leapfrog.Web.Application.Context.LeapfrogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Leapfrog.Web.Application.Context.LeapfrogDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            List<Payment> paymentList = new List<Payment>()
            {
                new Payment()
                {
                    Enrollment=null,
                    Amount=6000,
                    PaymentDate=DateTime.Now,
                    ModifiedDate=null,
                    Status=true
                },
                new Payment()
                {
                    Enrollment=null,
                    Amount=5000,
                    PaymentDate=DateTime.Now,
                    ModifiedDate=null,
                    Status=true
                }
            };
            paymentList.ForEach(p =>
            {
                context.Payments.Add(p);
                context.SaveChanges();
            });

        }
    }
}
