using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AddressBook.Models;

namespace AddressBook.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost("/contact/create")]
        public ActionResult CreateContact()
        {
            string newName = Request.Form["new-name"];
            string newPhoneNumber = Request.Form["new-phone-number"];
            string newAddress = Request.Form["new-address"];
            Contact newContact = new Contact (newName, newPhoneNumber, newAddress);
            newContact.Save();
            return View(newContact);
        }

        [Route("/ContactList")]
        public ActionResult ContactList()
        {
          List<Contact> allContacts = Contact.GetAll();
          return View(allContacts);
        }

        [HttpPost("/contact/list/clear")]
        public ActionResult ContactListClear()
        {
            Contact.ClearAll();
            return View();
        }
    }
}
