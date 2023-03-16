using System.Linq.Expressions;
namespace Contracts;


    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindaAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
