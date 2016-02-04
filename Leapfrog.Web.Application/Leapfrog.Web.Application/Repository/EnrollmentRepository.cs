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
    public interface IEnrollmentRepository : IGenericRepository<Enrollment>
    {

    }
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private LeapfrogDbContext db = new LeapfrogDbContext();

        public void Delete(int id)
        {
            Enrollment enrollment = db.Enrollments.Find(id);
            db.Enrollments.Remove(enrollment);
        }

        public IEnumerable<Enrollment> GetAll()
        {
            return db.Enrollments.ToList();
        }

        public Enrollment GetById(int id)
        {
            return db.Enrollments.Find(id);
        }

        public void Insert(Enrollment enrollment)
        {
            db.Enrollments.Add(enrollment);
        }

        public List<Enrollment> Search(Expression<Func<Enrollment>> e)
        {
            throw new NotImplementedException();
        }

        public void Update(Enrollment enrollment)
        {
            db.Entry(enrollment).State = EntityState.Modified;
        }
    }
}