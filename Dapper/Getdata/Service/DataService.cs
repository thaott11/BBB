using System.Reflection;
using Getdata.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Getdata.Service
{
    public interface IDataService
    {
        Task<List<Employess>> GetData();
        Task<bool> CreateData(string entityType, string jsonData);
        Task<bool> DeleteData(Guid? id);
        Task<bool> UpdateEmployess(string entityType, string jsonData);
    }
    public class DataService(ISmartSoftService smartSoftService, DapperContext _db) : IDataService
    {
        public async Task<bool> CreateData(string entityType, string jsonData)
        {
            var type = GetEntityType(entityType);
            var entity = JsonConvert.DeserializeObject(jsonData, type);
            if (entity == null)
            {
                throw new ArgumentException("lỗi sai data");
            }
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        private Type GetEntityType(string entityType)
        {
            var assembly = Assembly.GetAssembly(typeof(DapperContext));
            var type = assembly.GetTypes().FirstOrDefault(t => t.Name == entityType);
            if (type == null)
            {
               return null;
            }
            return type;
        }

        public async Task<List<Employess>> GetData()
        {
            string Condition = "";
            string Colums = "Employess";
            string Parameter = "Employess";
            var result = new {Condition, Colums, Parameter};
            var data = await smartSoftService.GetListObjectAsync<Employess>("getdata", result);
            return data;
        }
        
        public async Task<bool> DeleteData(Guid? id)
        {
            string parameter = "Employess";
            string Condition = id.ToString();
            var result = new { parameter, Condition };
            var data = await smartSoftService.GetListObjectAsync<Employess>("DeleteData", result);
            return true;
        }

        public async Task<bool> UpdateEmployess(string entityType, string jsonData)
        {
            var type = GetEntityType(entityType);
            var entity = JsonConvert.DeserializeObject(jsonData, type);
            if (entity == null)
            {
                throw new ArgumentException("lỗi sai data");
            }
             _db.Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
