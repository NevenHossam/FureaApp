using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace FureaApp.IRepositories
{
	public interface IRepository<T> where T:class
	{
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(Guid id);
        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate); 
        Task Create(T obj);
        Task<bool> Update(T obj);
        Task<bool> Delete(Guid id);
    }
}