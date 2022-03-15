using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newApi.Model
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
           
            TblCarts = new HashSet<TblCart>();
            TblIotUsers = new HashSet<TblIotUsers>();
            TblShippingDetails = new HashSet<TblShippingDetails>();
        }
        public bool hasIotSystem { get; set; }
        public string fristName { get; set; }
        public string lastName { get; set; }
        public virtual ICollection<TblCart> TblCarts { get; set; }
        public virtual ICollection<TblIotUsers> TblIotUsers { get; set; }
        public virtual ICollection<TblShippingDetails> TblShippingDetails { get; set; }
    }
}
