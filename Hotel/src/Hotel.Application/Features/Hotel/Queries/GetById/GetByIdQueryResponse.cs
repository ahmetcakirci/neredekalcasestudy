using Domain.DTOs;

namespace Application.Features.Hotel.Queries.GetById;

public class GetByIdQueryResponse
{
    public Guid? Id { get; set; }
    public string AuthorizedFirstName { get; set; }
    public string AuthorizedLastName { get; set; }
    public string CompanyTitle { get; set; }
    public List<ContactInfoDto> ContactInfos { get; set; }
}