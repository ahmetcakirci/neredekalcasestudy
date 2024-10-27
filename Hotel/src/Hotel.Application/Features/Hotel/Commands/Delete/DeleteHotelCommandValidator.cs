using FluentValidation;

namespace Application.Features.Hotel.Commands.Delete;

public class DeleteHotelCommandValidator:AbstractValidator<DeleteHotelCommand>
{
    public DeleteHotelCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty().NotNull();
    }
}