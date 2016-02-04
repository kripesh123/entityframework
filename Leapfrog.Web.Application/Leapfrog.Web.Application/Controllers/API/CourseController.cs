using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Leapfrog.Web.Application.Context;
using Leapfrog.Web.Application.Models;
using Leapfrog.Web.Application.Repository;

namespace Leapfrog.Web.Application.Controllers.API
{
    public class CourseController : ApiController
    {
        private ICourseRepository _courseRepository=new CourseRepository();

        private LeapfrogDbContext db = new LeapfrogDbContext();

        public CourseController()
        {

        }
        public CourseController(ICourseRepository _courseRepository)
        {
            this._courseRepository = _courseRepository;
        }
        // GET: api/Course
        public IEnumerable<Course> GetCourses()
        {
            return _courseRepository.GetAll();
        }

        // GET: api/Course/5
        [ResponseType(typeof(Course))]
        public IHttpActionResult GetCourse(int id)
        {
            Course course = _courseRepository.GetById(id);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        

        // POST: api/Course
        [ResponseType(typeof(Course))]
        public IHttpActionResult PostCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Courses.Add(course);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = course.Id }, course);
        }

        // DELETE: api/Course/5
        [ResponseType(typeof(Course))]
        public IHttpActionResult DeleteCourse(int id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            db.Courses.Remove(course);
            db.SaveChanges();

            return Ok(course);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CourseExists(int id)
        {
            return db.Courses.Count(e => e.Id == id) > 0;
        }
    }
}