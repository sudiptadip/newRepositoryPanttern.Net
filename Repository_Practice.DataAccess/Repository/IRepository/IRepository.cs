using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Practice.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetALL(string? includePropertyes = null);
        T Get(Expression<Func<T,bool>> filter, string? includePropertyes = null);
        void Add(T entity);
        void Remove(T entity);
    }
}
