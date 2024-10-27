using Domain.Enums;

namespace Domain.Entities;

public class ContactInfo
{
    public Guid Id { get; set; } 
    public Guid HotelId { get; set; } 
    
    public ContactInfoType InfoType { get; set; } 
    public string InfoContent { get; set; } 
    
    public Hotel Hotel { get; set; }
}