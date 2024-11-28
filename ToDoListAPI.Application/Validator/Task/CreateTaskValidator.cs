﻿using FluentValidation;
using ToDoListAPI.Application.DTOs.Task;

public class CreateTaskValidator : AbstractValidator<CreateTask>
{
	public CreateTaskValidator()
	{
		RuleFor(x => x.Title)
			.NotEmpty().WithMessage("Title is required.")
			.MaximumLength(100).WithMessage("Title length can't exceed 100 characters.");

		RuleFor(x => x.Description)
			.NotEmpty().WithMessage("Description is required.")
			.MaximumLength(500).WithMessage("Description length can't exceed 500 characters.");

		RuleFor(x => x.TeacherId)
			.NotEmpty().WithMessage("TeacherId is required.");

		RuleFor(x => x.Deadline)
			.NotEmpty().WithMessage("Deadline is required.")
			.Must(BeAFutureDate).WithMessage("Deadline must be a future date.");
	}

	private bool BeAFutureDate(DateTime date)
	{
		return date > DateTime.Now;
	}
}