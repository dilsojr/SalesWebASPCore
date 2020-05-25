﻿using SalesWebMvcASPCore.Data;
using SalesWebMvcASPCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvcASPCore.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcASPCoreContext _context;

        public SellerService(SalesWebMvcASPCoreContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Sellers.ToList();
        }
    }
}
