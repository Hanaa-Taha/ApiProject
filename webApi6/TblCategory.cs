﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace webApi6
{
    public partial class TblCategory
    {
        public TblCategory()
        {
            TblProduct = new HashSet<TblProduct>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<TblProduct> TblProduct { get; set; }
    }
}