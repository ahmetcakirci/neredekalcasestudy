namespace Application.Features.Hotel.Queries.GetLocationReport;

public class GetLocationReportQueryResponse
{
    public string LocationInfo { get; set; }
    public int? HotelCount { get; set; }
    public int? PhoneNumberCount { get; set; }
}