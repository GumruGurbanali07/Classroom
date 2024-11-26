using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Domain.Entities.Common;

namespace ToDoListAPI.Application.Repository
{
	public interface IWriteRepository<T>:IRepository<T> where T : BaseEntity
	{
		Task<bool> AddAsnyc(T model);
		Task<bool> RemoveAsync(string id);
		bool Remove(T model);
		bool Update(T model);
		Task<int> SaveAsync();

	}
	
}
