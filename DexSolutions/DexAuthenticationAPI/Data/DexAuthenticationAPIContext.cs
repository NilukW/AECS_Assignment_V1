#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DexAuthenticationAPI;

namespace DexAuthenticationAPI.Data
{
    public class DexAuthenticationAPIContext : DbContext
    {
        public DexAuthenticationAPIContext (DbContextOptions<DexAuthenticationAPIContext> options)
            : base(options)
        {
        }

        public DbSet<DexAuthenticationAPI.ApiUser> ApiUser { get; set; }
    }
}
