using WEB.Models;

namespace WEB.Service
{
    public interface IEmployessService
    {
        Task<List<Employess>> GetAllRecords();
    }
}
