using SalesWebMvcASPCore.Data;
using SalesWebMvcASPCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvcASPCore.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcASPCoreContext _context;

        public DepartmentService(SalesWebMvcASPCoreContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }

    }
}
