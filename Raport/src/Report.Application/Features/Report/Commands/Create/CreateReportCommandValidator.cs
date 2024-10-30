using FluentValidation;

namespace Report.Application.Features.Report.Commands.Create;

public class CreateReportCommandValidator:AbstractValidator<CreateReportCommand>
{
    public CreateReportCommandValidator()
    {
        RuleFor(c => c.LocationInfo).NotEmpty().NotNull();
    }
}