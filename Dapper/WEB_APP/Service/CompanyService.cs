using System.Net.Http.Json;
using WEB_APP.Models;

namespace WEB_APP.Service
{
    public interface ICompanyService
    {
        Task<List<company>> GetData();
    }
    public class CompanyService(HttpClient http) : ICompanyService
    {
        public async Task<List<company>> GetData()
        {
            var result = await http.GetFromJsonAsync<List<company>>("/Getdata/Company");
            return result;
        }
    }
}
