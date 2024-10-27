using MediatR;

namespace Application.Features.Hotel.Queries.GetById;

public class GetByIdQuery:IRequest<GetByIdQueryResponse>
{
    public Guid Id { get; set; }
}