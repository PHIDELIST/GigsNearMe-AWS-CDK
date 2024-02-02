using System;
using System.Linq;
using System.Linq.Expressions;

namespace GigsNearMe.Contracts
{
    // repository pattern adapted from https://code-maze.com/net-core-web-development-part4/
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
