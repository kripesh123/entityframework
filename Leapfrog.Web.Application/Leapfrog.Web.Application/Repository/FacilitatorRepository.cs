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
    public interface IFacilitatorRepository : IGenericRepository<Facilitator>
    {

    }
    public class FacilitatorRepository : IFacilitatorRepository
    {
        private LeapfrogDbContext db = new LeapfrogDbContext();

        public void Delete(int id)
        {
            Facilitator facilitator = db.Facilitators.Find(id);
            db.Facilitators.Remove(facilitator);  
        }

        public IEnumerable<Facilitator> GetAll()
        {
            return db.Facilitators.ToList();
        }

        public Facilitator GetById(int id)
        {
            return db.Facilitators.Find(id);
        }

        public void Insert(Facilitator facilitator)
        {
            db.Facilitators.Add(facilitator);
        }

        public List<Facilitator> Search(Expression<Func<Facilitator>> e)
        {
            throw new NotImplementedException();
        }

        public void Update(Facilitator facilitator)
        {
            db.Entry(facilitator).State = EntityState.Modified;
        }
    }
}