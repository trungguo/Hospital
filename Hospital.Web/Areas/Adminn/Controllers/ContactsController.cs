using Microsoft.AspNetCore.Mvc;
using Hospital.Service;
using Hospital.ViewModels;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("adminn")]
    public class ContactsController : Controller
    {

        private IContactService _contact;
        public ContactsController(IContactService contact)
        {
            _contact = contact  ;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_contact.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _contact.GetContactById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(ContactViewModel vm)
        {
            _contact.UpdateContact(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ContactViewModel vm)
        {
            _contact.InsertContact(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _contact.GetContactById(id);
            return RedirectToAction("Index");
        }



    }
}
