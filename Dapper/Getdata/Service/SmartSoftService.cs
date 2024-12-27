using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Getdata.Service
{
    public interface ISmartSoftService
    {
        Task<List<T>> GetListObjectAsync<T>(string storeName, object value);
        Task<T> GetSingleObjectAsync<T>(string storeName, object value);
        Task<bool> ExecuteNonQueryAsync(string storeName);
    }
    public class SmartSoftService(IConfiguration configuration): ISmartSoftService
    {
        private readonly string connStr = configuration.GetConnectionString("Myconnect")!;
        public async Task<List<T>> GetListObjectAsync<T>(string storeName, object value)
        {
            IEnumerable<T> arr;
            using (var conn = new SqlConnection(connStr))
            {
                if (conn.State == ConnectionState.Closed)
                { conn.Open(); }
                try
                {
                    arr = await conn.QueryAsync<T>(storeName, value, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally { conn.Close(); conn.Dispose(); }
            }
            return arr.ToList();
        }

        public async Task<T> GetSingleObjectAsync<T>(string storeName, object value)
        {
            IEnumerable<T> arr;
            using (var conn = new SqlConnection(connStr))
            {
                if (conn.State == ConnectionState.Closed) { conn.Open(); }
                try
                {
                    arr = await conn.QueryAsync<T>(storeName, value, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally { conn.Close(); conn.Dispose(); }
            }
            return arr.FirstOrDefault();
        }

        public async Task<bool> ExecuteNonQueryAsync(string storeName)
        {
            bool result = false;
            SqlConnection cnn = new SqlConnection(connStr);
            SqlCommand command = new SqlCommand(storeName, cnn);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
                command.CommandTimeout = 60;
                await command.ExecuteNonQueryAsync();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
            
        }
    }
}
