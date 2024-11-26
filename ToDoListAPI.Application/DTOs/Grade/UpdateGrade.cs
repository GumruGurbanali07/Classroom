using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI.Application.DTOs.Grade
{
	public class UpdateGrade
	{
		public Guid Id { get; set; }
		public int StudentGrade { get; set; }
	}
}
