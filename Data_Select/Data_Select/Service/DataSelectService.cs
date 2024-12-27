using Data_Select.Models;

namespace Data_Select.Service
{
    public interface IDataSelectService
    {
        public Task<List<Employess>> GetData();
    }
    public class DataSelectService(ISmartSoftService smartSoftService) : IDataSelectService
    {
        public async Task<List<Employess>> GetData()
        {
            string Parameter = "Employess";
            string condition = "Address = N'Thai binh'";
            string colums = " Name, Address, Department";
            var param = new { Parameter, condition, colums };
            var data = await smartSoftService.GetListObjectAsync<Employess>("GetData", param);
            return data;
        }

        
    }
}
