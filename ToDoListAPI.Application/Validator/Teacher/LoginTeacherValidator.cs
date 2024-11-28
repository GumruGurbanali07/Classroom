using FluentValidation;
using ToDoListAPI.Application.DTOs.Teacher;

public class LoginTeacherValidator : AbstractValidator<LoginTeacher>
{
	public LoginTeacherValidator()
	{
		RuleFor(x => x.Gmail)
			.NotEmpty().WithMessage("Gmail is required.")
			.EmailAddress().WithMessage("Email type is not true.");

		RuleFor(x => x.Password)
			.NotEmpty().WithMessage("Password is required.")
			.MinimumLength(6).WithMessage("Password must be min 6 characters.");
	}
}
