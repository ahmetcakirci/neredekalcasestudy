using FluentValidation;

namespace Application.Features.Hotel.Queries.GetLocationReport;

public class GetLocationReportQueryValidator:AbstractValidator<GetLocationReportQuery>
{
    public GetLocationReportQueryValidator()
    {
        RuleFor(c => c.LocationInfo).NotEmpty().NotNull();
    }
}