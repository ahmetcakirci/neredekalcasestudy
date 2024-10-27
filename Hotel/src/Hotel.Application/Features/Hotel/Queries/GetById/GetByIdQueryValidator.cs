using FluentValidation;

namespace Application.Features.Hotel.Queries.GetById;

public class GetByIdQueryValidator:AbstractValidator<GetByIdQuery>
{
    public GetByIdQueryValidator()
    {
        RuleFor(c => c.Id).NotEmpty().NotNull();
    }
}