using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAPI.Models
{
    public partial class dbSmartAgricultureContext :IdentityDbContext<AppUser>
    {
        

        public dbSmartAgricultureContext(DbContextOptions<dbSmartAgricultureContext> options)
            : base(options)
        {
        }

    }
}
