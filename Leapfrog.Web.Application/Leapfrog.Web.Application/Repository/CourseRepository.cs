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
    public interface ICourseRepository : IGenericRepository<Course>
    {

    }
    public class CourseRepository : ICourseRepository
    {
        private LeapfrogDbContext db = new LeapfrogDbContext();

        public void Delete(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
        }

        public IEnumerable<Course> GetAll()
        {
            return db.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return db.Courses.Find(id);
        }

        public void Insert(Course course)
        {
            db.Courses.Add(course);
        }

        public List<Course> Search(Expression<Func<Course>> e)
        {
            throw new NotImplementedException();
        }

        public void Update(Course course)
        {
            db.Entry(course).State = EntityState.Modified;
        }
    }
}