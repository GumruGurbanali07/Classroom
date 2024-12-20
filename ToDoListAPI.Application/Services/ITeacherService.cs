using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Application.DTOs.Classroom;
using ToDoListAPI.Application.DTOs.StudentTeacher;
using ToDoListAPI.Application.DTOs.Teacher;
using ToDoListAPI.Domain.Entities;
using Task = ToDoListAPI.Domain.Entities.Task;

namespace ToDoListAPI.Application.Services
{
	public interface ITeacherService
	{

		Task<bool> UpdateTeacherAsync(UpdateTeacher updateTeacher);
		Task<GetByIdTeacher> GetTeacherByUserIdAsync(string userId);
		Task<bool> CreateClassroomAsync(CreateClassroom createClassroom);
		Task<bool> AddStudentToClassroomAsync(StudentClass studentClass);
		Task<IEnumerable<object>> GetAllStudentsInClassroomAsync(string classroomId);
		Task<bool> RemoveStudentFromClassroomAsync(RemoveStudent removeStudent);


		

	}
}
