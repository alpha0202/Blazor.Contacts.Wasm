using Blazor.Contacts.Wasm.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Contacts.Wasm.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDbConnection _dbConnection;

        public ContactRepository(IDbConnection dbConnection)
        {
                _dbConnection = dbConnection;
        }

        public Task<IEnumerable<Contact>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<Contact> GetDetails(int id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> InsertContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteContact(int id)
        {
            throw new NotImplementedException();
        }



        public Task<bool> UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
