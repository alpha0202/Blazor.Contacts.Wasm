using Blazor.Contacts.Wasm.Repository;
using Blazor.Contacts.Wasm.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Contacts.Wasm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly IContactRepository _contactRepository;


        public ContactsController(IContactRepository contactRepository)
        {
                _contactRepository = contactRepository;
        }


        //insert

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contact contacts)
        {
            if (contacts == null)
                return BadRequest();

            if(string.IsNullOrWhiteSpace(contacts.FirstName))
            {
                ModelState.AddModelError("FirstName", "Primer nombre no puede estar vacío.");
            }
            if (string.IsNullOrWhiteSpace(contacts.LastName))
            {
                ModelState.AddModelError("LastName", "Apellido no puede estar vacío.");
            }


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _contactRepository.InsertContact(contacts);

            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody] Contact contacts)
        {
            if (contacts == null)
                return BadRequest();

            if (string.IsNullOrWhiteSpace(contacts.FirstName))
            {
                ModelState.AddModelError("FirstName", "Primer nombre no puede estar vacío.");
            }
            if (string.IsNullOrWhiteSpace(contacts.LastName))
            {
                ModelState.AddModelError("LastName", "Apellido no puede estar vacío.");
            }


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _contactRepository.UpdateContact(contacts);

            return NoContent();

        }


        [HttpGet]

        public async Task<IEnumerable<Contact>> Get() 
        {
            return await _contactRepository.GetAll();
        }

        [HttpGet("{id}")]

        public async Task<Contact> Get(int id)
        {
            return await _contactRepository.GetDetails(id);
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _contactRepository.DeleteContact(id);
        }


    }
}
