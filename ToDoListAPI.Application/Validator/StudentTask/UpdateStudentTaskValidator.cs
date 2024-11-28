using FluentValidation;
using ToDoListAPI.Application.DTOs.StudentTask;

public class UpdateStudentTaskValidator : AbstractValidator<UpdateStudentTask>
{
	public UpdateStudentTaskValidator()
	{
		RuleFor(x => x.Id)
			.NotEmpty().WithMessage("Id is required.");

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
