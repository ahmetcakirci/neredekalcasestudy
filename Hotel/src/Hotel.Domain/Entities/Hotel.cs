using Domain.Abstractions;

namespace Domain.Entities;

public class Hotel: Entity
{
    public string AuthorizedFirstName { get; set; }
    public string AuthorizedLastName { get; set; }
    public string CompanyTitle { get; set; }
    public ICollection<ContactInfo> ContactInfos { get; set; }
}