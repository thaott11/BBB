using System.Diagnostics.Contracts;
using System.Net.Http.Json;
using System.Net.WebSockets;
using Blazor_Web_App.Models;
using Microsoft.AspNetCore.Components;
using static System.Net.WebRequestMethods;

namespace Blazor_Web_App.Service
{
    public class ContactService(HttpClient http, NavigationManager navigationManager) : IContactService
    {
        [Parameter]
        public int id { get; set; }
        private Contact contact = new();
        private List<Contact> contactlist;
        private string? message;
        public async Task<Contact?> CreateContact(Contact contact)
        {
            var response = await http.PostAsJsonAsync("/api/Contact", contact);
            if (response.IsSuccessStatusCode)
            {
                navigationManager.NavigateTo("/ContactWeb");
                return contact;
            }
            else
            {
                message = $"Lỗi: {response.StatusCode}";
                return null;
            }
        }

        public async Task<bool> DeleteContact(int id)
        {
            var response = await http.DeleteAsync($"/api/Contact/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new Exception($"Không thể xóa Contact với ID {id}. Lỗi: {response.StatusCode}");
            }
        }

        public async Task<IEnumerable<Contact>> GetAllRecords()
        {
            var contacts = await http.GetFromJsonAsync<IEnumerable<Contact>>("/api/Contact");
            return contacts ?? new List<Contact>();
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            var respones = await http.PutAsJsonAsync($"/api/Contact/{contact.Id}", contact);
            if (respones.IsSuccessStatusCode)
            {
                navigationManager.NavigateTo("ContactWeb");
                return contact;
            }
            else
            {
                message = $"Lỗi: {respones.StatusCode}";
                return null;
            }
        }

        public async Task<IEnumerable<Contact>> SearchContacts(string? firstname, string? lastname, string? plane)
        {
            var queryParameters = new List<string>();
            if (!string.IsNullOrEmpty(firstname))
                queryParameters.Add($"firstname={Uri.EscapeDataString(firstname)}");
            if (!string.IsNullOrEmpty(lastname))
                queryParameters.Add($"lastname={Uri.EscapeDataString(lastname)}");
            if (!string.IsNullOrEmpty(plane))
                queryParameters.Add($"plane={Uri.EscapeDataString(plane)}");

            var queryString = string.Join("&", queryParameters);
            var requestUrl = $"/api/Contact/search?{queryString}";

            // Gửi yêu cầu HTTP GET
            var searchResults = await http.GetFromJsonAsync<IEnumerable<Contact>>(requestUrl);

            return searchResults ?? new List<Contact>();
        }

        public async Task<Contact?> GetById(int? id)
        {
            var searchResult = await http.GetFromJsonAsync<Contact>($"/api/Contact/{id}");
            return searchResult;
        }

    }
}
    