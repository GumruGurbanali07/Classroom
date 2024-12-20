using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Application.DTOs.Student;
using ToDoListAPI.Domain.Entities;
using Task = ToDoListAPI.Domain.Entities.Task;
using T = ToDoListAPI.Application.DTOs;

namespace ToDoListAPI.Application.Services
{
	public interface IStudentService
	{
		Task<bool> UpdateStudentAsync(UpdateStudent updateStudent);
		Task<GetByIdStudent> GetStudentByUserIdAsync(string userId);
		Task<bool> AcceptClassroomInviteAsync(string classroomId, string studentId);	
		Task<bool> LeaveClassroomAsync(string classroomId, string studentId);
		Task<IEnumerable<Classroom>> GetClassroomsForStudentAsync(string studentId);		
		Task<IEnumerable<string>> GetStudentUsernamesInClassroomAsync(string classroomId);


	

	}
}
