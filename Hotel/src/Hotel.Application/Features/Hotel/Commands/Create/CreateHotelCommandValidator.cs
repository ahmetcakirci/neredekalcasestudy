using FluentValidation;

namespace Application.Features.Hotel.Commands.Create;

public class CreateHotelCommandValidator:AbstractValidator<CreateHotelCommand>
{
    public CreateHotelCommandValidator()
    {
        RuleFor(c => c.AuthorizedFirstName).NotEmpty().NotNull();
        RuleFor(c => c.AuthorizedLastName).NotEmpty().NotNull();
        RuleFor(c => c.CompanyTitle).NotEmpty().NotNull();

    }
}