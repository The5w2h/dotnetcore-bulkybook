using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }

        //Dependency Injection
        public readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// CONCEPT: This id param should be the PRIMARY KEY (FIND and FIRSTORDEFAULT is preferred)
        /// Different ways of FINDING/SEARCHING a record based on ID, which is the PRIMARY KEY
        /// LAMBA expression is required for First, Single and Where
        /// Diff b.w. First and FirstOrDefault is IF NO RECORDS found then FIRST throws EXCEPTION, but FIRSTORDEFAULT RETURNS NULL
        /// Diff b.w. Single and First: If >1 records are found, Single throws and EXCEPTION, but First returns the first record
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
            //Category = _db.Category.First(u => u.Id == id); 
            //Category = _db.Category.FirstOrDefault(u => u.Id == id); 
            //Category = _db.Category.Where(u => u.Id == id).FirstOrDefault();
        }
       
        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "Name and Display Order cannot be same");
            }
            if (ModelState.IsValid)
            {
                _db.Category.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
