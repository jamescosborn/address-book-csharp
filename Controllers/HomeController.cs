using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;

namespace AddressBook.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("/categories")]
        public ActionResult Categories()
        {
            List<Category> allCategories = Category.GetAll();
            return View (allCategories);
        }

        [HttpGet("/categories/new")]
        public ActionResult CategoryForm()
        {
            return View();
        }

        [HttpPost("/categories")]
        public ActionResult AddCategory()
        {
            Category newCategory = new Category(Request.Form["category-name"]);
            List<Category> allCategories = Category.GetAll();
            return View("Categories", allCategories);
        }

        [HttpGet("/categories/{id}")]
        public ActionResult CategoryDetail(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Category selectedCategory = Category.Find(id);
            List<Contact> categoryContacts = selectedCategory.GetContacts();
            model.Add("category", selectedCategory);
            model.Add("contacts", categoryContacts);
            return View(model);
        }

        [HttpPost("/contacts")]
        public ActionResult AddContact()
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Category selectedCategory = Category.Find(Int32.Parse(Request.Form["category-id"]));
            List<Contact> categoryContacts = selectedCategory.GetContacts();
            string contactDescription = Request.Form["contact-description"];
            Contact newContact = new Contact(contactDescription);
            categoryContacts.Add(newContact);
            model.Add("contact", categoryContacts);
            model.Add("category", selectedCategory);
            return View("CategoryDetail", model);
        }

        [HttpGet("/contacts/{id}")]
        public ActionResult ContactDetail(int id)
        {
            Contact contact = Contact.Find(id);
            return View(contact);
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

        [Route("/contactlist")]
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
