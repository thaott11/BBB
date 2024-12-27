using System.Net.Http.Json;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using WEB_APP.ModelReques;
using WEB_APP.Models;
using static System.Net.WebRequestMethods;


namespace WEB_APP.Service
{
    public interface IEmployessService
    {
        Task<List<Employess>> Getdata();
        Task DeleteEmployess(Guid id);
        Task<bool> CreateData(CreateData request);
        Task<bool> UpdateEmployess(CreateData request);
    }
    public class EmployessService(HttpClient http, NavigationManager navigationManager) : IEmployessService
    {
        public async Task<List<Employess>> Getdata()
        {
            var resuld = await http.GetFromJsonAsync<List<Employess>>("/api/Getdata/employess");
            return resuld;
        }

        public async Task DeleteEmployess(Guid id)
        {
            var response = await http.DeleteAsync($"/api/Getdata/{id}");
            if (response.IsSuccessStatusCode)
            {
                await http.GetFromJsonAsync<List<Employess>>("/api/Getdata/employess");
            }
        }

        

        public async Task<bool> CreateData(CreateData request)
        {
            var response = await http.PostAsJsonAsync("/api/Getdata/create", request);
            var content = response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateEmployess(CreateData request)
        {
            var respones = await http.PutAsJsonAsync("/api/Getdata/Update", request);
            var content = respones.Content.ReadAsStringAsync();
            if (respones.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
