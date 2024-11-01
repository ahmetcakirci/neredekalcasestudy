using Report.Domain.Enums;

namespace Report.Domain.DTOs;

public class ReportDto
{
    public Guid? Id { get; set; }
    public DateTime RequestedDate { get; set; }
    public ReportStatus Status { get; set; } 
    public string LocationInfo { get; set; }
    public int? HotelCount { get; set; }
    public int? PhoneNumberCount { get; set; }
}