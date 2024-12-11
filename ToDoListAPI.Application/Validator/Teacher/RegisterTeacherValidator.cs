using FluentValidation;
using ToDoListAPI.Application.DTOs.Teacher;

public class RegisterTeacherValidator : AbstractValidator<RegisterTeacher>
{
	public RegisterTeacherValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty().WithMessage("Name is required.");

		RuleFor(x => x.Surname)
			.NotEmpty().WithMessage("Surname is required.");

		RuleFor(x => x.Subject)
			.NotEmpty().WithMessage("Subject is required.");

		RuleFor(x => x.Gmail)
			.NotEmpty().WithMessage("Gmail is required.")
			.EmailAddress().WithMessage("Email type is not true.");

		RuleFor(x => x.Password)
			.NotEmpty().WithMessage("Password is required.")
			.MinimumLength(6).WithMessage("Password must be min 6 characters.");

		RuleFor(x => x.ResetPassword)
			.NotEmpty().WithMessage("Reset Password is required.")
			.Equal(x => x.Password).WithMessage("Passwords must match.");
	}
}
