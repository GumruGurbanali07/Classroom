using FluentValidation;
using ToDoListAPI.Application.DTOs.Grade;

public class UpdateGradeValidator : AbstractValidator<UpdateGrade>
{
	public UpdateGradeValidator()
	{
		RuleFor(x => x.Id)
			.NotEmpty().WithMessage("Id is required.");
			

		RuleFor(x => x.StudentGrade)
			.InclusiveBetween(0, 100).WithMessage("Grade must be between 0 and 100.");
	}
}
