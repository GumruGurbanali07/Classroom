using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI.Application.Exceptions
{
	public class FailedRegisterException : Exception
	{
		public FailedRegisterException(string? message) : base(message)
		{
		}

		public FailedRegisterException(string? message, Exception? innerException) : base(message, innerException)
		{
		}
	}
}
