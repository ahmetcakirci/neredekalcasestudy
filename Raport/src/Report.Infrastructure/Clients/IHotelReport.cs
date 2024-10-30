using Refit;
using Report.Domain.DTOs;

namespace Report.Infrastructure.Clients;

public interface IHotelReport
{
    [Headers("Content-Type: application/json")]
    [Get("/api/Hotel/GetLocationReport")]
    Task<ApiResponse<ClientReportDto>> GetHotelLocation([AliasAs("locationInfo")] string? locationInfo);
}