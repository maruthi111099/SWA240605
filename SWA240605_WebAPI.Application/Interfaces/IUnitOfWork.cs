using System.Threading.Tasks;

namespace SWA240605_WebAPI.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
        Task RefreshAsync();
    }
}
