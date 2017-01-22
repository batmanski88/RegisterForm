using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zadanko.Models;
using Zadanko.Repository.IRepo;

namespace Zadanko.Repository.Repo
{
    public class ClientRepo : IClientRepo
    {
        private IAppDbContext _db;

        public ClientRepo(IAppDbContext db)
        {
            _db = db;
        }

        public void RegisterClient(RegistrationFormViewModel model, string[] interest)
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
                
                if (interest[i] != "")
                {
                    AdditionalInterest inter = new AdditionalInterest();
                    inter.Interest = interest[i];
                    Client.AdditionalInterests.Add(inter);
                }

                
            }
            _db.Clients.Add(Client);
           
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}