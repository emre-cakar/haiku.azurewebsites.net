using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using haiku_mvc.Models;

namespace haiku_mvc.Data
{
    public class haiku_mvcContext : DbContext
    {
        public haiku_mvcContext (DbContextOptions<haiku_mvcContext> options)
            : base(options)
        {
        }

        public DbSet<haiku_mvc.Models.FOLLOWERS>? FOLLOWERS { get; set; }

        public DbSet<haiku_mvc.Models.LIKES>? LIKES { get; set; }

        public DbSet<haiku_mvc.Models.POSTS>? POSTS { get; set; }

        public DbSet<haiku_mvc.Models.SHARES>? SHARES { get; set; }

        public DbSet<haiku_mvc.Models.USERS>? USERS { get; set; }
    }
}
