using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tamrin.APIModels;

namespace Tamrin.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        static List<Contact> contacts = new List<Contact>();
       public ContactsController() { }


        [HttpGet]
        public IEnumerable<Contact> GetAll()
        {
            return contacts;
        }

        [HttpPost]
        public bool Add(Contact contact)
        {
            contacts.Add(contact);
            return true;
        }

        [HttpPost]
        public bool Edit(Contact contact)
        {
            if (contacts.Select(c => c.Id).Contains(contact.Id))
            {
                contacts.Where(c => c.Id == contact.Id).Select( s => { s.Name = contact.Name; s.Number = contact.Number; return s; }).ToList();  
                return true;
            }
            return false;

        }

        [HttpPost]
        public bool Delete(int id)
        {
            if (contacts.Select(c => c.Id).Contains(id))
            {
                contacts.Remove(contacts.Where(c => c.Id == id).FirstOrDefault());
                return true;
            }
            return false;

        }
    }
}
