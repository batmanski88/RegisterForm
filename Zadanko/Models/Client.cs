using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zadanko.Models
{
    public class Client
    {
        public Client()
        {
            this.AdditionalInterests = new List<AdditionalInterest>();
        }
      
        public int ClientID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Receipt { get; set; }
        public string Interests { get; set; }
        public virtual ICollection<AdditionalInterest> AdditionalInterests { get; set; }
    }

    public enum Interest
    {
        Motoryzacja,
        Sport,
        Kino
    }

    public class AdditionalInterest
    {
        public int AdditionalInterestID { get; set; }
        public string Interest { get; set; }    
    }
}