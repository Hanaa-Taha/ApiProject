using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Models
{
    public partial class TblIotUser
    {
        public int IotId { get; set; }
        public string MembersId { get; set; }
        public string SerialNumber { get; set; }
        public bool? IsActive { get; set; }
        public string MemberId { get; set; }

        public virtual AspNetUser Member { get; set; }
    }
}
