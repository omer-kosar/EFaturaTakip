using EFaturaTakip.Common.Repository.Abstract;
using EFaturaTakip.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EFaturaTakip.Common.Repository.Concrete
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
        }
        public void Create(List<T> entities)
        {
            EFaturaTakipContext.Set<T>().AddRange(entities);
        }

        public void Delete(T entity)
        {
            EFaturaTakipContext.Set<T>().Remove(entity);
        }
        public void Delete(List<T> entities)
        {
            EFaturaTakipContext.Set<T>().RemoveRange(entities);
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
            EFaturaTakipContext.Entry(entity).State = EntityState.Modified;
            EFaturaTakipContext.Update<T>(entity);
        }
        public void Update(List<T> entities)
        {
            //EFaturaTakipContext.Entry(entities).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            EFaturaTakipContext.UpdateRange(entities);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return EFaturaTakipContext.Set<T>().SingleOrDefault(expression);
        }

        public IQueryable<T> FindByConditionAsQueryable(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
