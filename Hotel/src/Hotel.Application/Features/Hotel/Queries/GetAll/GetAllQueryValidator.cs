using FluentValidation;

namespace Application.Features.Hotel.Queries.GetAll;

public class GetAllQueryValidator:AbstractValidator<GetAllQuery>
{
    public GetAllQueryValidator()
    {
        RuleFor(c => c.PageSize).NotEmpty().NotNull();
        RuleFor(c => c.PageIndex).NotEmpty().NotNull();
    }
}