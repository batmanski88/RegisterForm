using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zadanko.Models;
using Zadanko.Repository.IRepo;

namespace Zadanko.Controllers
{
    public class RegistrationController : Controller
    {
        private IClientRepo _repo;

        public RegistrationController(IClientRepo repo)
        {
            _repo = repo;
        }
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RegisterForm()
        {
            var model = new RegistrationFormViewModel();
          
            return View(model);
        }

       [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult RegisterForm(RegistrationFormViewModel model, string[] interest)
        {


            if (ModelState.IsValid)
            {
              

                _repo.RegisterClient(model, interest);
                _repo.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = "Zarejestrowano pomyślnie";
                return View();
            }
            else
            {
                return View(model);
            }
        }

       
    }
}