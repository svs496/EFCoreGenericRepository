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
    public class SuppliersController : Controller
    {
        private readonly IWrapperService wrapperService;

        public SuppliersController(IWrapperService wrapperService)
        {
            this.wrapperService = wrapperService;
        }


         // GET: Suppliers
        public async Task<IActionResult> Index()
        {
            return View(await wrapperService.Supplier.GetAll());
        }

        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var supplier = await wrapperService.Supplier.GetById(id);
              
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,City,ContactNo,Email")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                await wrapperService.Supplier.Create(supplier);

                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var supplier = await wrapperService.Supplier.GetById(id);

            return View(supplier);

        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,City,ContactNo,Email")] Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await wrapperService.Supplier.Update(id, supplier);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var supplier = await wrapperService.Supplier.GetById(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await wrapperService.Supplier.Delete(id);

            return RedirectToAction(nameof(Index));
        }

       
    }
}
