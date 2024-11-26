using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Application.Repository;
using ToDoListAPI.Domain.Entities.Common;
using ToDoListAPI.Persistence.Context;

namespace ToDoListAPI.Persistence.Repository
{
	public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
	{
		private readonly AppDbContext _context;

		public WriteRepository(AppDbContext context)
		{
			_context = context;
		}

		public DbSet<T> Table => _context.Set<T>();

		public async Task<bool> AddAsnyc(T model)
		{
			EntityEntry<T> entry=await Table.AddAsync(model);
			return entry.State==EntityState.Added;
		}
		public bool Remove(T model)
		{
			EntityEntry<T> entry=Table.Remove(model);
			return entry.State==EntityState.Deleted;
		}
		public  async Task<bool> RemoveAsync(string id)
		{
			T values=await Table.FirstOrDefaultAsync(x=>x.Id==Guid.Parse(id));
			return Remove(values);
		  
		}

		public async Task<int> SaveAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public  bool Update(T model)
		{
			EntityEntry<T> entry= Table.Update(model);
			return entry.State==EntityState.Modified;
		}
	}
}
