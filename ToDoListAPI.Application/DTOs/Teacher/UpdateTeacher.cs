﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI.Application.DTOs.Teacher
{
	public class UpdateTeacher
	{
		public string Id { get; set; }
		public string UserId { get; set; }
		public string Subject { get; set; }
	}
}
