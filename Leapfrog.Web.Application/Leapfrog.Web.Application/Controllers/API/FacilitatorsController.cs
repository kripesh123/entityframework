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
    public class FacilitatorsController : ApiController
    {
        private IFacilitatorRepository facilitatorRepository = new FacilitatorRepository();
        private LeapfrogDbContext db = new LeapfrogDbContext();

        public FacilitatorsController()
        {

        }
        public FacilitatorsController(IFacilitatorRepository facilitatorRepository)
        {
            this.facilitatorRepository = facilitatorRepository;
        }
        // GET: api/Facilitators
        public IEnumerable<Facilitator> GetFacilitators()
        {
            return facilitatorRepository.GetAll();
        }

        // GET: api/Facilitators/5
        [ResponseType(typeof(Facilitator))]
        public IHttpActionResult GetFacilitator(int id)
        {
            Facilitator facilitator = facilitatorRepository.GetById(id);
            if (facilitator == null)
            {
                return NotFound();
            }

            return Ok(facilitator);
        }

        // PUT: api/Facilitators/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFacilitator(int id, Facilitator facilitator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != facilitator.Id)
            {
                return BadRequest();
            }

            db.Entry(facilitator).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacilitatorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Facilitators
        [ResponseType(typeof(Facilitator))]
        public IHttpActionResult PostFacilitator(Facilitator facilitator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Facilitators.Add(facilitator);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = facilitator.Id }, facilitator);
        }

        // DELETE: api/Facilitators/5
        [ResponseType(typeof(Facilitator))]
        public IHttpActionResult DeleteFacilitator(int id)
        {
            Facilitator facilitator = db.Facilitators.Find(id);
            if (facilitator == null)
            {
                return NotFound();
            }

            db.Facilitators.Remove(facilitator);
            db.SaveChanges();

            return Ok(facilitator);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FacilitatorExists(int id)
        {
            return db.Facilitators.Count(e => e.Id == id) > 0;
        }
    }
}