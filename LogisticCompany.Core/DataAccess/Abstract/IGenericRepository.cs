using LogisticCompany.Core.Entities.Concrete;
using LogisticCompany.Core.Utilities.Results;
using System.Linq.Expressions;

namespace LogisticCompany.Core.DataAccess.Abstract
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> GetAll();

        T GetById(int id);

        IDataResult<T> Add(T entity);
        IDataResult<T> Update(T entity);

        IDataResult<T> Delete(T entity);

        IDataResult<List<T>> AddRange(List<T> entities);

        IDataResult<List<T>> UpdateRange(List<T> entities);
        IDataResult<List<T>> DeleteRange(List<T> entities);
        bool Exist(Expression<Func<T, bool>> filter);
    }
}
