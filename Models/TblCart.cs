using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class TblCart
    {
        public int CartId { get; set; }
        public int? ProductId { get; set; }
        public string MemberId { get; set; }
        public int? CartStatusId { get; set; }

        public virtual TblCartStatus CartStatus { get; set; }
        public virtual AspNetUser Member { get; set; }
        public virtual TblProduct Product { get; set; }
    }
}
