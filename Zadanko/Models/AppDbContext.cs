using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Zadanko.Repository.IRepo;

namespace Zadanko.Models
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext()
            :base("AppDB")
        {

        }

        
        public DbSet<Client> Clients { get; set; }
        public DbSet<AdditionalInterest> AdditionalInterests { get; set; }
    }
}