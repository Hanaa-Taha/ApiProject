using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class TblCartStatus
    {
        public TblCartStatus()
        {
            TblCarts = new HashSet<TblCart>();
        }

        public int CartStatusId { get; set; }
        public string CartStatus { get; set; }

        public virtual ICollection<TblCart> TblCarts { get; set; }
    }
}
