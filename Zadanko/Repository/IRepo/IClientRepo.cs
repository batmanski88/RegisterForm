using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanko.Models;

namespace Zadanko.Repository.IRepo
{
    public interface IClientRepo
    {
        void RegisterClient(Client client);
        void SaveChanges();
    }
}
