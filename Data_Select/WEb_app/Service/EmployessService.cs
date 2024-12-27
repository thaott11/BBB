using System.Net.Http.Json;
using WEB_APP.Models;
using static System.Net.WebRequestMethods;

namespace WEB_APP.Service
{
    public class EmployessService(HttpClient http) : IEmployessService
    {

        public async Task<List<Employess>> GetAllRecords()
        {
            var response = await http.GetAsync("/WeatherForecast/getdata?tableName=Employees");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Employess>>();
        }
    }
}
