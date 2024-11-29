using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI.Application.Exceptions
{
	public class FailedLoginException : Exception
	{
		public FailedLoginException(string? message) : base(message)
		{
		}

		public FailedLoginException(string? message, Exception? innerException) : base(message, innerException)
		{
		}
	}
}
