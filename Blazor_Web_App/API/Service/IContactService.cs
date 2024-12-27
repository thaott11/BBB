using API.Models;

namespace API.Service
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> Getdata();
        Task<Contact> Getbyid(int id);
        Task<Contact> Create(Contact contact);
        Task<Contact> Update(Contact contact);
        Task Delete(int id);
        Task<IEnumerable<Contact>> SearchContacts( string? firstname, string? lastname, string? plane);
    }
}
