using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Suppliers.WebApp.Pages
{
    public class IndexModel : PageModel
    {
       
       private readonly AppDbContext _db;
       public IList<Supplier> Suppliers {get;set;}
       public IndexModel(AppDbContext db)
       {
           _db=db;
       }
[BindProperty(SupportsGet=true)]
public string SearchString { get; set; }
public SelectList Names {get;set;}
public string Userselect { get; set; }
public async Task OnGetAsync(){
     var supps=from s in _db.Suppliers
     select s;
     if (!string.IsNullOrEmpty(SearchString))
     {
         supps=supps.Where(s=>s.Name.Contains(SearchString));
     }
     
    Suppliers=await _db.Suppliers.AsNoTracking().ToListAsync();
}
public async Task<IActionResult> OnPostDeleteAsync(int id){
    var supplier_find=await _db.Suppliers.FindAsync(id);
    if(supplier_find!=null){
        _db.Suppliers.Remove(supplier_find);
        await _db.SaveChangesAsync();
    }
    return RedirectToPage(); 
}


    }
}
