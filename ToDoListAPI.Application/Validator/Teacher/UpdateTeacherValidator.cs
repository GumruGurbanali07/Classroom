using FluentValidation;
using ToDoListAPI.Application.DTOs.Teacher;

public class UpdateTeacherValidator : AbstractValidator<UpdateTeacher>
{
	public UpdateTeacherValidator()
	{
		RuleFor(x => x.Id)
			.NotEmpty().WithMessage("Id is required.");

		

		RuleFor(x => x.UserId)
			.NotEmpty().WithMessage("Surname is required.");

		RuleFor(x => x.Subject)
			.NotEmpty().WithMessage("Subject is required.");

		
	}
}
