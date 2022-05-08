#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DexAddressServiceApi;

namespace DexAddressServiceApi.Data
{
    public class DexAddressServiceApiContext : DbContext
    {
        public DexAddressServiceApiContext (DbContextOptions<DexAddressServiceApiContext> options)
            : base(options)
        {
        }

        public DbSet<DexAddressServiceApi.Wallet> Wallet { get; set; }
    }
}
