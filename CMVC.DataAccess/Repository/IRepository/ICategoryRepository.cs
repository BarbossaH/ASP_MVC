using System;
using CMVC.Models;

namespace CMVC.DataAccess.Repository.IRepository
{
	public interface ICategoryRepository : IRepository<Category>
	{
		void Update(Category obj);
		void Save();
	}
}

