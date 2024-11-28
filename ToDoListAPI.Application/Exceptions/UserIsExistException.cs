using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI.Application.Exceptions
{
	public class UserIsExistException : Exception
	{
		public UserIsExistException(string? message) : base(message)
		{
		}

		public UserIsExistException(string? message, Exception? innerException) : base(message, innerException)
		{
		}
	}
}
