using GetRates.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetRates.DAL.Data
{
    public class CryptoContext : DbContext
    {
        public DbSet<Crypto> Cryptos { get; set; }
        public DbSet<CryptoQuote> Quotes { get; set; }
        public DbSet<Platform> Platforms { get; set; }

        public CryptoContext(DbContextOptions<CryptoContext> options) : base(options)
        {
        }
    }
}
