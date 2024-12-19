using dapper.Models;
using dapper.Service;

namespace Dapper2.Service
{
    public interface IEmployService
    {
        public Task<List<Employess>> GetList();
    }

    public class EmployService(ISmartSoftData smartSoftData) : IEmployService
    {
        public async Task<List<Employess>> GetList()
        {
            string parameter = "Employ";
            string condition = "Address = N'Ha Noi'";
            var param = new { parameter, condition };
            var data = await smartSoftData.GetListObjectAsync<Employess>("GetData", param);

            return data;
        }

    }
}
