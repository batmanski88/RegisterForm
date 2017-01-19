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
            model.AdditionalInterests = new List<string>();
            return View(model);
        }

       [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult RegisterForm(RegistrationFormViewModel model, string[] interest)
        {


            if (ModelState.IsValid)
            {
                var Client = new Client()
                {
                    FName = model.FName,
                    LName = model.LName,
                    Email = model.Email,
                    Password = model.Password,
                    Interests = string.Join(",", model.Interests.Select(s => s.ToString())),
                    Receipt = model.Receipt

                };

                for (int i = 0; i < interest.Length; i++)
                {
                    AdditionalInterest inter = new AdditionalInterest();
                    if (interest[i] != null)
                    {
                        inter.Interest = interest[i];
                    }

                    Client.AdditionalInterests.Add(inter);
                }

                _repo.RegisterClient(Client);
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