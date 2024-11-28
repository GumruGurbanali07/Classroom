using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI.Application.Validator.StudentTask
{
	public class FutureDateAttribute: ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			if (value == null)
			{
				return true;
			}
			if(value is DateTime date)
			{
				return date > DateTime.Now;
			}
			return false;	
		}
	}
}
