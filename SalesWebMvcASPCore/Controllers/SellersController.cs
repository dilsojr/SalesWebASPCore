using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvcASPCore.Models;
using SalesWebMvcASPCore.Models.ViewModels;
using SalesWebMvcASPCore.Services;
using SalesWebMvcASPCore.Services.Exceptions;

namespace SalesWebMvcASPCore.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            var department = _departmentService.FindAll();
            var viewModel = new SellerformViewModel { Departments = department };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _sellerService.FindByID(id.Value);
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _sellerService.FindByID(id.Value);
            if (obj == null)
                return NotFound();

            return View(obj);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _sellerService.FindByID(id.Value);
            if (obj == null)
                return NotFound();

            List<Department> departments = _departmentService.FindAll();
            SellerformViewModel viewModel = new SellerformViewModel{ Departments = departments, Seller = obj };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.Id)
                return NotFound();

            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }

}