using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tamrin.APIModels;
using Tamrin.Database;
using Tamrin.Database.Models;

namespace Tamrin.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        //static List<Contact> contacts = new List<Contact>();
        private readonly TamrinDBContext db;

       public ContactsController(TamrinDBContext tamrinDBContext) {
            db = tamrinDBContext;
        }

        [HttpGet]
        public IEnumerable<ContactAPIModel> GetAll()
        {
            return db.Contacts.Select(c => new ContactAPIModel
            {
                Id = c.Id,
                Name = c.Name,
                Number = c.Number,
                Addresses = c.Addresses.Select(x=> x.Address).ToList(),
                Factors = c.Factors.Select(f=> f.Title).ToList()
            });
        }

        [HttpPost]
        public bool Add(ContactAPIModel contact)
        {
            db.Contacts.Add(new Contact
            {
                Name = contact.Name,
                Number = contact.Number,
                Addresses = contact.Addresses.Select(c=> new ContactAddress
                {
                    Address = c
                }).ToList()
            });
            db.SaveChanges();
            return true;
        }

        [HttpPost]
        public bool Edit(ContactAPIModel contact)
        {
            var dbContact = db.Contacts.Where(c => c.Id == contact.Id).FirstOrDefault();
            if (dbContact == null)
                throw new Exception("Contact not found");

            dbContact.Name = contact.Name;
            dbContact.Number = contact.Number;
            dbContact.Addresses = contact.Addresses.Select(c => new ContactAddress
            {
                Address = c
            });

            db.SaveChanges();
            return true;

        }

        [HttpPost]
        public bool Delete(int id)
        {
            var dbContact = db.Contacts.Where(c => c.Id == id).FirstOrDefault();
            if (dbContact == null)
                throw new Exception("Contact not found");

            db.Contacts.Remove(dbContact);
            db.SaveChanges();
            return true;

        }
    }
}
