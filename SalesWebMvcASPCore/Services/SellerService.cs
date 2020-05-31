using Microsoft.EntityFrameworkCore;
using SalesWebMvcASPCore.Data;
using SalesWebMvcASPCore.Models;
using SalesWebMvcASPCore.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindByID(int id)
        {
            return _context.Sellers.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Sellers.Find(id);
            _context.Sellers.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if (!_context.Sellers.Any(x => x.Id == obj.Id))
                throw new NotFoundException("Id not found");

            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
