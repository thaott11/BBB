using System.Data;
using System.Reflection;
using Dapper;
using Getdata.Models;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace Getdata.Service
{
    public interface ICompanyDataservice
    {
        Task<IEnumerable<dynamic>> GetData(string condition, string colums, string parameter);
        Task<bool> CreateData(string entityType, string jsonData);
        Task<bool> DeleteData(Guid? id);
        Task<bool> UpdateCompany(string entityType, string jsonData);
    }
    public class CompanyDataService(SmartSoftService smartSoftService, DapperContext _db) : ICompanyDataservice

    {
        public async Task<bool> CreateData(string entityType, string jsonData)
        {
            var type = GetEmtytype(entityType);
            var entity = JsonConvert.DeserializeObject(jsonData, type);
            if (entity == null)
            {
                throw new ArgumentException("lỗi sai data");
            }
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        private Type GetEmtytype(string entityType)
        {
            var assembly = Assembly.GetAssembly(typeof(DapperContext));
            var type = assembly.GetTypes().FirstOrDefault(t => t.Name == entityType);
            if (type == null)
            {
                return null;
            }
            return type;
        }

        public Task<bool> DeleteData(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> Getcompany()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCompany(string entityType, string jsonData)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<dynamic>> GetData(string condition, string colums, string parameter)
        {
            using (var connection = new SqlConnection("Myconnect"))
            {
                string Condition = "";
                string Colums = "Company";
                string Parameter = "Company";
                var result = new { condition, Colums, Parameter };
                var data = await smartSoftService.GetListObjectAsync<Employess>("getdata", result);
                return data;
            }
        }
    }
}
