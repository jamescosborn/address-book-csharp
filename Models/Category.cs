using System.Collections.Generic;

namespace AddressBook.Models
{
  public class Category
  {
     private static List<Category> _AllContacts = new List<Category> {};
     private string _name;
     private int _id;
     private List<Contact> _contacts;

     public Category(string categoryName)
     {
       _name = categoryName;
       _instances.Add(this);
       _id = _AllContacts.Count;
       _contacts = new List<Contact>{};
     }

     public string GetName()
     {
       return _name;
     }

     public int GetId()
     {
       return _id;
     }

     public static List<Category> GetAll()
     {
       return _AllContacts;
     }

     public static void Clear()
     {
       _AllContacts.Clear();
     }

     public static Category Find(int searchId)
     {
       return _instances[searchId-1];
     }
   }
 }
