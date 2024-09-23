using SWA240605_WebAPI.Application.DTOs;
using System.Threading.Tasks;

namespace SWA240605_WebAPI.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
