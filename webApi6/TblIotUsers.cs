﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace webApi6
{
    public partial class TblIotUsers
    {
        public int IotId { get; set; }
        public int? MembersId { get; set; }
        public string SerialNumber { get; set; }
        public bool? IsActive { get; set; }

        public virtual TblMembers Members { get; set; }
    }
}