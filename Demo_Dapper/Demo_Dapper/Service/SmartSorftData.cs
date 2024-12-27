using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Demo_Dapper.Service
{
    public interface ISmartSorftData
    {
        Task<List<T>> GetListObjectAsync<T>(string storeName, object value);
        Task<T> GetSingleObjectAsync<T>(string storeName);
        Task<bool> ExecuteNonQueryAsync(string storeName);
    }
    public class SmartSorftData(IConfiguration configuration) : ISmartSorftData
    {
        private readonly string connStr = configuration.GetConnectionString("MyConnect");
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

        public async Task<T> GetSingleObjectAsync<T>(string storeName)
        {
            IEnumerable<T> arr;
            T rst = default;
            using (var conn = new SqlConnection(connStr))
            {
                if (conn.State == ConnectionState.Closed) { conn.Open(); }
                try
                {
                    arr = await conn.QueryAsync<T>(storeName, commandTimeout: 120, commandType: CommandType.Text);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally { conn.Close(); conn.Dispose(); }
            }
            if (arr.Count() > 0)
            { return arr.First(); }
            else return rst;
        }
    }
}
