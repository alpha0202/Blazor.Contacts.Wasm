using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Contacts.Wasm.Shared
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Adrress { get; set; }

        public string FullName {

            get
            {
                return LastName + "," + FirstName;
            } 
        
        
        }
    }
}
