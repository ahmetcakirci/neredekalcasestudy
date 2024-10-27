using Domain.Enums;

namespace Domain.DTOs;

public class ContactInfoDto
{
    public ContactInfoType InfoType { get; set; }
    public string InfoContent { get; set; }
}