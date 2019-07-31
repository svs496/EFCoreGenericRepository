using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductAppCore2.Data;
using ProductAppCore2.Models;
using ProductAppCore2.Services;

namespace ProductAppCore2._1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IWrapperService wrapperService;

        public ProductsController(IWrapperService wrapperService)
        {
            this.wrapperService = wrapperService;
        }

        // GET: Products
        public IActionResult Index()
        {
            return View(wrapperService.Product.Get(p => p.Supplier).ToList());
        }

        // GET: Products/Details/5
        public IActionResult Details(int id)
        {

            var product = wrapperService.Product.GetByIdWithInclude(id, (p => p.Supplier));

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {

            var suppliers = await wrapperService.Supplier.GetAll();

            ViewData["SupplierId"] = new SelectList(suppliers, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SupplierId")] Product product)
        {
            if (ModelState.IsValid)
            {
                await wrapperService.Product.Create(product);

                return RedirectToAction(nameof(Index));
            }

            var suppliers = await wrapperService.Supplier.GetAll();

            ViewData["SupplierId"] = new SelectList(suppliers, "Id", "Name");

            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var product = await wrapperService.Product.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            var suppliers = await wrapperService.Supplier.GetAll();

            ViewData["SupplierId"] = new SelectList(suppliers, "Id", "Name");

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SupplierId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await wrapperService.Product.Update(id, product);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction(nameof(Index));
            }

            var suppliers = await wrapperService.Supplier.GetAll();

            ViewData["SupplierId"] = new SelectList(suppliers, "Id", "Name");

            return View(product);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int id)
        {

            var product = wrapperService.Product.GetByIdWithInclude(id, (p => p.Supplier));

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await wrapperService.Product.Delete(id);

            return RedirectToAction(nameof(Index));
        }


    }
}
