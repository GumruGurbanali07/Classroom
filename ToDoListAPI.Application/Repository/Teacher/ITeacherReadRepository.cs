﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Domain.Entities;

namespace ToDoListAPI.Application.Repository
{
	public interface ITeacherReadRepository:IReadRepository<Teacher>
	{
		Task<Teacher> GetByUserIdAsync(string userId);
	}
}
