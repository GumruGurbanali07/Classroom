using FluentValidation;
using ToDoListAPI.Application.DTOs.StudentTask;

public class CreateStudentTaskValidator : AbstractValidator<CreateStudentTask>
{
	public CreateStudentTaskValidator()
	{
		RuleFor(x => x.StudentId)
			.NotEmpty().WithMessage("StudentId is required.");

		RuleFor(x => x.TaskId)
			.NotEmpty().WithMessage("TaskId is required.");

		RuleFor(x => x.CompletionDate)
			.NotEmpty().WithMessage("CompletionDate is required.")
			.Must(BeAFutureDate).WithMessage("CompletionDate must be a future date.");

		RuleFor(x => x.IsCompleted)
			.NotNull().WithMessage("IsCompleted status must be specified.");
	}

	private bool BeAFutureDate(DateTime date)
	{
		return date > DateTime.Now;
	}
}
