using FluentValidation;
using ToDoListAPI.Application.DTOs.Grade;

public class CreateGradeValidator : AbstractValidator<CreateGrade>
{
	public CreateGradeValidator()
	{
		RuleFor(x => x.StudentTaskId)
			.NotEmpty().WithMessage("StudentTaskId is required.");
			

		RuleFor(x => x.StudentGrade)
			.InclusiveBetween(0, 100).WithMessage("Grade must be between 0 and 100.");
	}
}
