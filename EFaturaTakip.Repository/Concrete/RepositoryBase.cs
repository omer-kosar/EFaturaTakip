using EFaturaTakip.Entities;
using EFaturaTakip.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Repository.Concrete
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected EFaturaTakipContext EFaturaTakipContext { get; set; }

        public RepositoryBase(EFaturaTakipContext eFaturaTakipContext)
        {
            EFaturaTakipContext = eFaturaTakipContext;
        }

        public void Create(T entity)
        {
            EFaturaTakipContext.Set<T>().Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            EFaturaTakipContext.Set<T>().Remove(entity);
            Save();
        }

        public IEnumerable<T> FindAll()
        {
            return EFaturaTakipContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return EFaturaTakipContext.Set<T>().Where(expression);
        }

        public int Save()
        {
            return EFaturaTakipContext.SaveChanges();
        }

        public void Update(T entity)
        {
            EFaturaTakipContext.Set<T>().Update(entity);
            Save();
        }
    }
}
