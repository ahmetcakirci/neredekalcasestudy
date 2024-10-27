namespace Domain.Entities;

public class Hotel
{
    public Guid Id { get; set; } 
    public string AuthorizedFirstName { get; set; }
    public string AuthorizedLastName { get; set; }
    public string CompanyTitle { get; set; }
    public ICollection<ContactInfo> ContactInfos { get; set; }
}