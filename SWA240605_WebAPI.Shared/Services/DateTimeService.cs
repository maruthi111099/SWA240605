using SWA240605_WebAPI.Application.Interfaces;

namespace SWA240605_WebAPI.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUTC => DateTime.UtcNow;
    }
}
