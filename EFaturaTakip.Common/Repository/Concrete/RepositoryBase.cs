using EFaturaTakip.Common.Repository.Abstract;
using EFaturaTakip.Entities;
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
            EFaturaTakipContext.Update<T>(entity);
            Save();
        }
        public void Update(List<T> entities)
        {
            EFaturaTakipContext.UpdateRange(entities);
            Save();
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
