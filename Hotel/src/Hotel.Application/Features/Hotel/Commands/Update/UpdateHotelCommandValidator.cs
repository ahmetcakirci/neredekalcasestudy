using FluentValidation;

namespace Application.Features.Hotel.Commands.Update;

public class UpdateHotelCommandValidator:AbstractValidator<UpdateHotelCommand>
{
    public UpdateHotelCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty().NotNull();
        RuleFor(c => c.AuthorizedFirstName).NotEmpty().NotNull();
        RuleFor(c => c.AuthorizedLastName).NotEmpty().NotNull();
        RuleFor(c => c.CompanyTitle).NotEmpty().NotNull();

    }
}