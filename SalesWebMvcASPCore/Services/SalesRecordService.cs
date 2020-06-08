using Microsoft.EntityFrameworkCore;
using SalesWebMvcASPCore.Data;
using SalesWebMvcASPCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvcASPCore.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMvcASPCoreContext _context;

        public SalesRecordService(SalesWebMvcASPCoreContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? dateMin, DateTime? dateMax)
        {
            var result = from obj in _context.SalesRecords select obj;
            if (dateMin.HasValue)
            {
                result = result.Where(x => x.Date >= dateMin.Value);
            }
            if (dateMax.HasValue)
            {
                result = result.Where(x => x.Date <= dateMax.Value);
            }
            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department,SalesRecord>>>FindByDateGroupingAsync(DateTime? dateMin, DateTime? dateMax)
        {
            var result = from obj in _context.SalesRecords select obj;
            if (dateMin.HasValue)
            {
                result = result.Where(x => x.Date >= dateMin.Value);
            }
            if (dateMax.HasValue)
            {
                result = result.Where(x => x.Date <= dateMax.Value);
            }
            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Department)
                .ToListAsync();
        }

    }
}
