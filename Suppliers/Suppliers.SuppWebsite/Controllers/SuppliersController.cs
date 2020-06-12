using System;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using suppliersReference;
using Suppliers.SuppWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace Suppliers.SuppWebsite.Controllers
{
    public class suppliersController : Controller
    {
      
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            SuppliersClients suppliersClient = new suppliersClient();

            var suppliers = await suppliersClient.GetAllAsync();

            var result = suppliers
                .Select(s => new SupplierViewModel
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToArray();

            await suppliersClient.CloseAsync();

            return View(result);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            SuppliersClient suppliersClient = new SuppliersClient();

            var supplier = await suppliersClient.GetByIdAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            var result = new SupplierViewModel
            {
                Id = s.Id,
                Name = s.Name
            };

            await suppliersClient.CloseAsync();

            return View(result);
        }

        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<ActionResult> Create(SupplierViewModel supplier)
        {
            try
            {
               SupplierClient suppliersClient = new SuppliersClient();

                var suppliersDto = new SuppliersDto
                {
                    Id = supplier.Id,
                    Name = supplier.Name
                };

                await suppliersClient.CreateAsync(supplierDto);

                await suppliersClient.CloseAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            suppliersClient suppliersClient = new suppliersClient();

            var supplier = await suppliersClient.GetByIdAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            var result = new supplierViewModel
            {
                Id = supplier.Id,
                Name = supplier.Name
            };

            await suppliersClient.CloseAsync();

            return View(result);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, SupplierViewModel supplier)
        {
            supplier.Id = id;

            try
            {
                suppliersClient suppliersClient = new suppliersClient();

                var supplierDto = new supplierDto
                {
                    Id = supplier.Id,
                    Name = supplier.Name
                };

                await suppliersClient.UpdateAsync(supplierDto);

                await suppliersClient.CloseAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            suppliersClient suppliersClient = new suppliersClient();

            var supplier = await suppliersClient.GetByIdAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            var result = new supplierViewModel
            {
                Id = supplier.Id,
                Name = supplier.Name
            };

            await suppliersClient.CloseAsync();

            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                suppliersClient suppliersClient = new suppliersClient();

                await suppliersClient.DeleteAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}