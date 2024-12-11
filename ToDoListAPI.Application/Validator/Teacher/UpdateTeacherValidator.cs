using FluentValidation;
using ToDoListAPI.Application.DTOs.Teacher;

public class UpdateTeacherValidator : AbstractValidator<UpdateTeacher>
{
	public UpdateTeacherValidator()
	{
		RuleFor(x => x.Id)
			.NotEmpty().WithMessage("Id is required.");

		RuleFor(x => x.Name)
			.NotEmpty().WithMessage("Name is required.");

		RuleFor(x => x.Surname)
			.NotEmpty().WithMessage("Surname is required.");

		RuleFor(x => x.Subject)
			.NotEmpty().WithMessage("Subject is required.");

		RuleFor(x => x.NewGmail)
			.NotEmpty().WithMessage("Gmail is required.")
			.EmailAddress().WithMessage("Email type is not true.");

		RuleFor(x => x.NewPassword)
			.NotEmpty().WithMessage("Password is required.")
			.MinimumLength(6).WithMessage("Password must be min 6 characters.");
	}
}
