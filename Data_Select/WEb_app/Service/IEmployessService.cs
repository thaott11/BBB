using WEB_APP.Models;

namespace WEB_APP.Service
{
    public interface IEmployessService
    {
        Task<List<Employess>> GetAllRecords();
    }
}
