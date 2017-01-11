using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Zadanko.Models;

namespace Zadanko.Repository.IRepo
{
    public interface IAppDbContext
    {
        DbSet<Client> Clients { get; set; }
        DbSet<AdditionalInterest> AdditionalInterests { get; set; }
        int SaveChanges();
    }
}