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
    public interface IStudentRepository : IGenericRepository<Student>
    {

    }
    public class StudentRepository : IStudentRepository
    {
        private LeapfrogDbContext db = new LeapfrogDbContext();

        public void Delete(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
        }

        public IEnumerable<Student> GetAll()
        {
            return db.Students.ToList();
        }

        public Student GetById(int id)
        {
            return db.Students.Find(id);
        }

        public void Insert(Student student)
        {
            db.Students.Add(student);
        }

        public List<Student> Search(Expression<Func<Student>> e)
        {
            throw new NotImplementedException();
        }

        public void Update(Student student)
        {
            db.Entry(student).State = EntityState.Modified;
        }
    }
}