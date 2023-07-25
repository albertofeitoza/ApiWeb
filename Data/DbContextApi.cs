using ApiWeb.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Data
{
    public class DbContextApi : DbContext
    {

        public DbContextApi()
        {
        }

        public DbContextApi(DbContextOptions<DbContextApi> options) 
            : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }

    }
}
