using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI.Application.DTOs.Grade
{
	public class UpdateGrade
	{
		public Guid Id { get; set; }
		[Required]
		[MaxLength(100, ErrorMessage = "Set grade over 100")]
		public int StudentGrade { get; set; }
	}
}
