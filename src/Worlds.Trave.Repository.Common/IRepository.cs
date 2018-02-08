using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Worlds.Trave.Repository.Common
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Get(bool @readonly = false);
        IQueryable<T> Search(Expression<Func<T, bool>> predicate, bool @readonly = false);
        void Add(T entity);
        void AddBatch(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
    }
}
