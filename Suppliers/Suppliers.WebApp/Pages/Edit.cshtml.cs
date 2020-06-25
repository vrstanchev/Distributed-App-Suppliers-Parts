using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
namespace Suppliers.WebApp.Pages
{
    public class EditModel : PageModel
    {
       private readonly AppDbContext _db;
       [BindProperty]
       public Supplier Supplier { get; set; }
       public EditModel(AppDbContext db)
       {
           _db=db;
       }
       public async Task<IActionResult> OnGetAsync(int id){
           Supplier=await _db.Suppliers.FindAsync(id);
           if (Supplier==null)
           {
               return RedirectToAction("./Index");
           }
           return Page();
       }
       public async Task<IActionResult> OnPostAsync(){

           if (!ModelState.IsValid)
           {
               return Page();
           }
           _db.Attach(Supplier).State=EntityState.Modified;
         
           try
           {
               await  _db.SaveChangesAsync();
           }
           catch (DbUpdateConcurrencyException e)
           {
               
               throw new Exception($"Supplier {Supplier.Name} is not found!",e);
           }
             return RedirectToAction("./Index");
       }
    }
}
