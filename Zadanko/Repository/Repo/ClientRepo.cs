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

        public void RegisterClient(Client client)
        {
            _db.Clients.Add(client);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}