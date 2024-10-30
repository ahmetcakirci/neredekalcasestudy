using Report.Domain.Enums;

namespace Report.Application.Features.Report.Queries.GetAll;

public class GetAllQueryResponse
{
    public DateTime RequestedDate { get; set; }
    public ReportStatus Status { get; set; } 
    public string? Location { get; set; }
    public int? HotelCount { get; set; }
    public int? PhoneNumberCount { get; set; }
}