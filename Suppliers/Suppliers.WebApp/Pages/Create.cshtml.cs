using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Suppliers.WebApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;
        [BindProperty]
        public Supplier Supplier {get;set;}
        public CreateModel(AppDbContext db)
        {
            _db=db;
        }
        public async Task<IActionResult> OnPostAsync(){
            if (!ModelState.IsValid)
            {
                return Page();
            }
_db.Suppliers.Add(Supplier);
await _db.SaveChangesAsync();

return RedirectToPage("/Index");
        }
    }
}
