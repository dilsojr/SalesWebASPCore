﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvcASPCore.Models;

namespace SalesWebMvcASPCore.Data
{
    public class SalesWebMvcASPCoreContext : DbContext
    {
        public SalesWebMvcASPCoreContext (DbContextOptions<SalesWebMvcASPCoreContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }
        public DbSet<Seller> Sellers { get; set; }
    }
}
