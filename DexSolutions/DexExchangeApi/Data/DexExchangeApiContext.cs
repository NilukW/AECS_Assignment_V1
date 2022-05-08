#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DexExchangeApi;

namespace DexExchangeApi.Data
{
    public class DexExchangeApiContext : DbContext
    {
        public DexExchangeApiContext (DbContextOptions<DexExchangeApiContext> options)
            : base(options)
        {
        }

        public DbSet<DexExchangeApi.WalletCurrency> WalletCurrency { get; set; }
    }
}
