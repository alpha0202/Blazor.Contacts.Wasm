using Blazor.Contacts.Wasm.Shared;
using Dapper;
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

        public async Task<IEnumerable<Contact>> GetAll()
        {
            var sql = @"SELECT Id, FirstName, LastName, Phone, Address 
                        FROM ContactsDB
                        ";

            return await _dbConnection.QueryAsync<Contact>(sql, new {  });
        }



        public async Task<Contact> GetDetails(int id)
        {
            var sql = @"SELECT Id, FirstName, LastName, Phone, Address 
                        FROM ContactsDB
                        WHERE Id = @Id"; 

            return await _dbConnection.QueryFirstOrDefaultAsync<Contact>(sql, new {Id = id});
        }



        public async Task<bool> InsertContact(Contact contact)
        {
            try
            {
                var sql = @"INSERT INTO ContactsDB(FirstName, LastName, Phone, Address)
                                    VALUES(@FirstName, @LastName, @Phone, @Address)";


                var result = await _dbConnection.ExecuteAsync(sql, 
                    new
                    {
                         contact.FirstName, 
                         contact.LastName,
                         contact.Phone,
                         contact.Adrress
                    }                
                    );

                return result > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }





        public async Task<bool> UpdateContact(Contact contact)
        {
            try
            {
                var sql = @"UPDATE ContactsDB
                                    SET FirstName = @FirstName  , 
                                    LastName = @LastName , 
                                    Phone = @Phone , 
                                    Address = @Address 
                                    WHERE Id = @Id";


                var result = await _dbConnection.ExecuteAsync(sql,
                    new
                    {
                        contact.Id,
                        contact.FirstName,
                        contact.LastName,
                        contact.Phone,
                        contact.Adrress
                    }
                    );

                return result > 0;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



        public  async Task<bool> DeleteContact(int id)
        {
            var sql = @"DELETE FROM ContactsDB WHERE Id = @Id";

            var result = await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

    }
}
