using FluentValidation;
using ToDoListAPI.Application.DTOs.Student;

public class LoginStudentValidator : AbstractValidator<LoginStudent>
{
	public LoginStudentValidator()
	{
		RuleFor(x => x.Gmail)
			.NotEmpty().WithMessage("Email is required.")
			.EmailAddress().WithMessage("Email format is invalid.");

		RuleFor(x => x.Password)
			.NotEmpty().WithMessage("Password is required.")
			.MinimumLength(6).WithMessage("Password must be at least 6 characters.");
	}
}
