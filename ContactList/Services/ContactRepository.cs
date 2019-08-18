using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactList.Models;

namespace ContactList.Services
{

    public class ContactRepository
    {
        private const string CacheCtKey = "StoreContact";
        public ContactRepository()
        {
            var ctxCt = HttpContext.Current;

            if (ctxCt != null)
            {
                if (ctxCt.Cache[CacheCtKey] == null)
                {
                    var contacts = new List<Contact>
                    {
                new Contact
                {
                    Id = 1, FirstName = "Test",LastName = "Test",Email="Test@gmail.com",PhoneNumber="8007947895",Status="Active"
                }
                    };

                    ctxCt.Cache[CacheCtKey] = contacts;
                }
            }
        }
        public List<Contact> GetAllContacts()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (List<Contact>)ctx.Cache[CacheCtKey];
            }

            return new List<Contact>
                {
            new Contact
            {
                Id = 0,
                FirstName = "Tetst ",
                LastName="Test"
            }
                };
        }
        public bool SaveContact(Contact contact)
        {
            var ctxCtSave = HttpContext.Current;

            if (ctxCtSave != null)
            {
                try
                {
                    var currentData = ((List<Contact>)ctxCtSave.Cache[CacheCtKey]).ToList();
                    currentData.Add(contact);
                    ctxCtSave.Cache[CacheCtKey] = currentData;

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
        public bool UpdateContact(Contact contact)
        {
            var ctxUpdate = HttpContext.Current;

            if (ctxUpdate != null)
            {
                try
                {
                    
                    var currentData = ((List<Contact>)ctxUpdate.Cache[CacheCtKey]).ToList();
                    (from k in currentData
                     where k.Id == contact.Id
                     select k).ToList().ForEach(k => k.FirstName = contact.FirstName);
                    (from k in currentData
                     where k.Id == contact.Id
                     select k).ToList().ForEach(k => k.LastName  = contact.LastName );
                    (from k in currentData
                     where k.Id == contact.Id
                     select k).ToList().ForEach(k => k.Email  = contact.Email );
                    (from k in currentData
                     where k.Id == contact.Id
                     select k).ToList().ForEach(k => k.PhoneNumber  = contact.PhoneNumber );
                    (from k in currentData
                     where k.Id == contact.Id
                     select k).ToList().ForEach(k => k.Status  = contact.Status );
                    ctxUpdate.Cache[CacheCtKey] = currentData;

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
        public bool DeleteContact(int ID)
        {
            var ctxCt = HttpContext.Current;

            if (ctxCt != null)
            {
                try
                {
                    var currentData = ((List<Contact>)ctxCt.Cache[CacheCtKey]).ToList();

                    var  contactInfo = currentData.Where(s => s.Id == ID).FirstOrDefault();
                    currentData.Remove(contactInfo);
                    ctxCt.Cache[CacheCtKey] = currentData;

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
        public bool AddContact(Contact contact)
        {
            var ctxCt = HttpContext.Current;

            if (ctxCt != null ) 
            {
                if (ctxCt.Cache[CacheCtKey] != null)
                {
                    try
                    {
                        var currentData = ((List<Contact>)ctxCt.Cache[CacheCtKey]).ToList();
                        if (currentData.Capacity > 0)
                        {
                            var maxID = currentData.OrderByDescending(s => s.Id).FirstOrDefault();
                            var contact1 = new Contact { Id = (maxID.Id) + 1, FirstName = contact.FirstName, LastName = contact.LastName, Email = contact.Email, PhoneNumber = contact.PhoneNumber, Status = contact.Status };
                            currentData.Add(contact1);
                            ctxCt.Cache[CacheCtKey] = currentData;

                            return true;
                        }
                        else
                        {
                            return AddContactInner(contact);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        return false;
                    }
                }
                else
                {
                    return AddContactInner(contact);
                }
            }
            else
            {
                return AddContactInner(contact);
            }


            //return false;
        }
        public bool AddContactInner(Contact contact)
        {
            var ctxCt = HttpContext.Current;
            try
            {
                var contacts = new List<Contact>
                    {
                new Contact
                {
                    Id = 1, FirstName = contact.FirstName, LastName = contact.LastName, Email = contact.Email, PhoneNumber = contact.PhoneNumber, Status = contact.Status
                }
                    };

                ctxCt.Cache[CacheCtKey] = contacts;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}