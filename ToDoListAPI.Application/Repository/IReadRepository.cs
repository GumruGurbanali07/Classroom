using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Domain.Entities.Common;

namespace ToDoListAPI.Application.Repository
{
	 public interface IReadRepository<T>:IRepository<T> where T : BaseEntity
	{
		IQueryable<T> GetAll();
		Task<T> GetByIdAsync(string id, bool tracking = true);
	}
}
