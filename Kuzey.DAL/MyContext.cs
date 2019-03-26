using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Kuzey.MODELS.Entities;
using Kuzey.MODELS.IdentityEntities;

namespace Kuzey.DAL
{
    public class MyContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products{ get; set; }
    }
}
