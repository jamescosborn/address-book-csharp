using System.Collections.Generic;
using System;

namespace AddressBook.Models
{
  public class Contact
  {
    private string _name;
    private string _phoneNumber;
    private string _address;

    private static List<Contact> _AllContacts = new List<Contact> {};

    public Contact (string name, string phoneNumber, string address)
    {
      _name = name;
      _phoneNumber = phoneNumber;
      _address = address;
    }

    public void Save()
    {
      _AllContacts.Add(this);
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public string GetPhoneNumber()
    {
      return _phoneNumber;
    }

    public void SetPhoneNumber(string newPhoneNumber)
    {
      _phoneNumber = newPhoneNumber;
    }

    public string GetAddress()
    {
      return _address;
    }

    public void SetAddress(string newAddress)
    {
      _address = newAddress;
    }

    public static List<Contact> GetAll()
    {
      return _AllContacts;
    }

    public static void ClearAll()
    {
      _AllContacts.Clear();
    }
  }
}
