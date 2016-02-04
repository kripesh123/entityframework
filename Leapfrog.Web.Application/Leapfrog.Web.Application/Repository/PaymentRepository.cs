using Leapfrog.Web.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using Leapfrog.Web.Application.Context;
using System.Data.Entity;

namespace Leapfrog.Web.Application.Repository
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        IEnumerable<Payment> GetByEnrollmentId(int enrollmentId);
    }
    public class PaymentRepository : IPaymentRepository
    {
        private LeapfrogDbContext db = new LeapfrogDbContext();

        public void Delete(int id)
        {
            Payment payment = db.Payments.Find(id);
            db.Payments.Remove(payment);
        }

        public IEnumerable<Payment> GetAll()
        {
            return db.Payments.ToList();
        }

        public Payment GetById(int id)
        {
            return db.Payments.Find(id);
        }

        public IEnumerable<Payment> GetByEnrollmentId(int enrollmentId)
        {
            throw new NotImplementedException();
        }

        public void Insert(Payment payment)
        {
            db.Payments.Add(payment);
        }

        public List<Payment> Search(Expression<Func<Payment>> e)
        {
            throw new NotImplementedException();
        }

        public void Update(Payment payment)
        {
            db.Entry(payment).State = EntityState.Modified;
        }
    }
}