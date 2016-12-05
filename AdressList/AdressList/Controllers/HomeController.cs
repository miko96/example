using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdressList.Models;

namespace AdressList.Controllers
{
    public class HomeController : Controller
    {
        IAdressListRepository repository;
       
        // GET: Home
        public HomeController(IAdressListRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.AdressNotes);
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View(new AdressNote());
        }

        [HttpPost]
        public ActionResult Add(AdressNote item)
        {
            if (ModelState.IsValid)
            {
                repository.Add(item);
                return RedirectToAction("Index");
            }
            else
                return View("Index");
        }

        [HttpGet]
        public ViewResult Update(int id)
        {
            var itemForUpdate = repository.AdressNotes
                .Where(r => r.Id == id).FirstOrDefault();
            return View(itemForUpdate);
        }

        [HttpPost]
        public ActionResult Update(AdressNote item)
        {
            if (ModelState.IsValid && repository.Update(item))
                return RedirectToAction("Index");
            return View("Index");
        }

        public ActionResult Remove(int id)
        {
            repository.Remove(id);
            return RedirectToAction("Index");           
        }    
    }
}