using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newApi.Model
{
    public class TblCategory
    {
        public TblCategory()
        {
            TblProducts = new HashSet<TblProduct>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<TblProduct> TblProducts { get; set; }
    }
}
