using FluentValidation;
using ToDoListAPI.Application.DTOs.Student;

public class RegisterStudentValidator : AbstractValidator<RegisterStudent>
{
	public RegisterStudentValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty().WithMessage("Name is required.");

		RuleFor(x => x.Surname)
			.NotEmpty().WithMessage("Surname is required.");

		RuleFor(x => x.Gmail)
			.NotEmpty().WithMessage("Email is required.")
			.EmailAddress().WithMessage("Email format is invalid.");

		RuleFor(x => x.Password)
			.NotEmpty().WithMessage("Password is required.")
			.MinimumLength(6).WithMessage("Password must be at least 6 characters.");

		RuleFor(x => x.ResetPassword)
			.NotEmpty().WithMessage("Please confirm your password.")
			.Equal(x => x.Password).WithMessage("Passwords do not match.");
	}
}
