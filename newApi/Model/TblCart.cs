using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newApi.Model
{
    public class TblCart
    {
        public int CartId { get; set; }
        public int? ProductId { get; set; }
        public string MemberId { get; set; }
        public int? CartStatusId { get; set; }

        public virtual TblCartStatus CartStatus { get; set; }
        public virtual AppUser Member { get; set; }
        public virtual TblProduct Product { get; set; }
    }
}
