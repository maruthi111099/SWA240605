using System;

namespace SWA240605_WebAPI.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUTC { get; }
    }
}
