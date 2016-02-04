using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Leapfrog.Web.Application.Repository
{
    public interface IGenericRepository<E> where E :class
    {
        void Insert(E e);
        void Update(E e);
        void Delete(int id);
        E GetById(int id);
        IEnumerable<E> GetAll();
        List<E> Search(Expression<Func<E>> e);
    }
}
