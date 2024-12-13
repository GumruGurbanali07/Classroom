using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Application.Repository;
using ToDoListAPI.Domain.Entities;
using ToDoListAPI.Persistence.Context;

namespace ToDoListAPI.Persistence.Repository
{
	public class TeacherReadRepository : ReadRepository<Teacher>, ITeacherReadRepository
	{
		public TeacherReadRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<Teacher> GetByUserIdAsync(string userId)
		{
			return await _context.Teachers.FirstOrDefaultAsync(x => x.UserId == userId);
		}
	}
}
