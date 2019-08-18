using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactList.Models;
using ContactList.Services;
using static ContactList.Models.Contact;

namespace ContactList.Controllers

{
    public class ContactController : Controller
    {
        private ContactRepository ctRepo;
        public ContactController()
        {
            this.ctRepo = new ContactRepository();
        }
        // GET: Contact
        [HandleError(View="Error")]
        public ActionResult GetAllCt()
        {
           List<Contact> listCtObj = this.ctRepo.GetAllContacts();
            return View(listCtObj);
        }
        [HandleError(View = "Error")]
        [ActionName("Edit")]
        public ActionResult EditContact(int Id)
        {
            var contactObj = this.ctRepo.GetAllContacts().Where(s => s.Id == Id).FirstOrDefault();
            return View(contactObj);
        }
        [HandleError(View = "Error")]
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditContact(Contact contactObj)
        {
            Boolean flagIsUpdate = this.ctRepo.UpdateContact(contactObj);
            if ( flagIsUpdate)
            {
                return RedirectToAction("GetAllCt");
                
            }
            return View("Error");
        }
        [HandleError(View = "Error")]
        public ActionResult Delete(int ID)
        {
            Boolean flagIsDeleteSuccessful = this.ctRepo.DeleteContact(ID);
            if (flagIsDeleteSuccessful)
            {
                return RedirectToAction("GetAllCt");
            }
            return View("Error");
        }
        [HandleError(View = "Error")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HandleError(View = "Error")]
        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            Boolean flagIsCreateSucc = this.ctRepo.AddContact(contact);
            if (flagIsCreateSucc)
            {
                return RedirectToAction("GetAllCt");
            }
            return View("Error");
        }
    }

}