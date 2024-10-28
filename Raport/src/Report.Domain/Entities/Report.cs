using Report.Domain.Abstractions;
using Report.Domain.Enums;

namespace Report.Domain.Entities;

public class Report: Entity
{
    public DateTime RequestedDate { get; set; }
    public ReportStatus Status { get; set; } 
    public string Location { get; set; }
    public int HotelCount { get; set; }
    public int PhoneNumberCount { get; set; }
}