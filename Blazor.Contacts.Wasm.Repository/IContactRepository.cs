using Blazor.Contacts.Wasm.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Contacts.Wasm.Repository
{
    public interface IContactRepository
    {

        Task<bool> InsertContact(Contact contact);

        Task<bool> UpdateContact(Contact contact);
        Task<bool> DeleteContact(int id);

        Task<IEnumerable<Contact>> GetAll();

        Task<Contact> GetDetails(int id);



    }
}
