using Demo_Dapper.Models;

namespace Demo_Dapper.Service
{
    public interface IEmployessService
    {
        public Task<List<Employess>> Getall();
    }
    public class EmployessService (ISmartSorftData smartSorftData) : IEmployessService
    {
        public async Task<List<Employess>> Getall()
        {
            string Parameter = "Employess";
            string Condition = "Department = N'dev'";
            var param = new { Parameter, Condition };
            var data = await smartSorftData.GetListObjectAsync<Employess>("GetData", param);
            return data;
        }
    }
}
