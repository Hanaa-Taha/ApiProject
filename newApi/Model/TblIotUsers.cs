using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newApi.Model
{
    public class TblIotUsers
    {
        public int IotId { get; set; }
        public string SerialNumber { get; set; }
        public bool? IsActive { get; set; }
        public string MemberId { get; set; }

        public virtual AppUser Member { get; set; }
    }
}
