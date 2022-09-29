using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Common.Repository.Abstract
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> FindAll();
        T Get(Expression<Func<T, bool>> expression);
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> FindByConditionAsQueryable(Expression<Func<T, bool>> expression);

        void Create(T entity);
        void Create(List<T> entities);
        void Update(T entity);
        void Update(List<T> entities);
        void Delete(T entity);
        void Delete(List<T> entities);
        int Save();
    }
}
