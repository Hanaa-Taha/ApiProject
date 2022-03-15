using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newApi.Model
{
    public class TblCartStatus
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
