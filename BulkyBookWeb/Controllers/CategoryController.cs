using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        // GET: /<controller>/

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            try
            {
                IEnumerable<Category> objCategoryList = _db.Categories;
                return View(objCategoryList); // the *IEnumberable*, that is passed to the view, should be added in *@model* inside the *View*
            }
            catch (Exception ex)
            {
                return View("Error " + ex.StackTrace);
            }

        }

        //GET
        public IActionResult Create()
        {
            return View();
            // the *IEnumberable*, that is passed to the view, should be added in *@model* inside the *View*
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            try
            {
                if (obj.Name == obj.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("CustomeError", "Name and Display Order cannot exactly match");
                }
                if (ModelState.IsValid)
                {
                    _db.Categories.Add(obj);
                    _db.SaveChanges();
                    TempData["success"] = "Category created successfully.";
                    return RedirectToAction("Index");
                }
                return View(obj);
                // the *IEnumberable*, that is passed to the view, should be added in *@model* inside the *View*
                // Above RedirectToAction will route to the current controller's Index action method.
                // User RedirectToAction("ActionMethod","ControllerName")
            }
            catch (Exception ex)
            {
                return View("Error " + ex.StackTrace);
            }
            
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
            // the *IEnumberable*, that is passed to the view, should be added in *@model* inside the *View*
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            try
            {
                if (obj.Name == obj.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("CustomeError", "Name and Display Order cannot exactly match");
                }
                if (ModelState.IsValid)
                {
                    _db.Categories.Update(obj);
                    _db.SaveChanges();
                    TempData["success"] = "Category updated successfully.";
                    return RedirectToAction("Index");
                }
                return View(obj);
                // the *IEnumberable*, that is passed to the view, should be added in *@model* inside the *View*
                // Above RedirectToAction will route to the current controller's Index action method.
                // User RedirectToAction("ActionMethod","ControllerName")
            }
            catch (Exception ex)
            {
                return View("Error " + ex.StackTrace);
            }

        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
            // the *IEnumberable*, that is passed to the view, should be added in *@model* inside the *View*
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {
            try
            {
                if (obj.Name == obj.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("CustomeError", "Name and Display Order cannot exactly match");
                }
                if (ModelState.IsValid)
                {
                    _db.Categories.Remove(obj);
                    _db.SaveChanges();
                    TempData["success"] = "Category deleted successfully.";
                    return RedirectToAction("Index");
                }
                return View(obj);
                // the *IEnumberable*, that is passed to the view, should be added in *@model* inside the *View*
                // Above RedirectToAction will route to the current controller's Index action method.
                // User RedirectToAction("ActionMethod","ControllerName")
            }
            catch (Exception ex)
            {
                return View("Error " + ex.StackTrace);
            }

        }
    }
}

