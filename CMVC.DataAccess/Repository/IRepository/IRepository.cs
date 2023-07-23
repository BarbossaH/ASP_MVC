using System;
using System.Linq.Expressions;

namespace CMVC.DataAccess.Repository.IRepository
{
	public interface IRepository<T> where T:class
	{
		// T will be generic models on which we want to perform the crud operation
		// or rather we want to interact with the DB context, such as Category model
		//

		IEnumerable<T> GetAll();
		T Get(Expression<Func<T, bool>> filter);
		void Add(T entity);
		//void Update(T entity); //it's said that the update usually is complicated. so it will be dealt with individually.
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entities);
	}
}

