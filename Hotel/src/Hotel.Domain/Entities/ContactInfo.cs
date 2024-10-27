using Domain.Abstractions;
using Domain.Enums;

namespace Domain.Entities;

public class ContactInfo: Entity
{
    public string HotelId { get; set; } 
    
    public ContactInfoType InfoType { get; set; } 
    public string InfoContent { get; set; } 
    
    public Hotel Hotel { get; set; }
}