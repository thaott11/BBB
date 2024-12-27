using System.Collections;
using Blazor_Web_App.Models;

namespace Blazor_Web_App.Service
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllRecords();
        Task<IEnumerable<Contact>> SearchContacts(string? firstname, string? lastname, string? plane);
        Task<Contact> CreateContact(Contact contact);
        Task<Contact> UpdateContact(Contact contact);
        Task<Contact> GetById(int? id);
        Task <bool> DeleteContact(int id);
    }
}