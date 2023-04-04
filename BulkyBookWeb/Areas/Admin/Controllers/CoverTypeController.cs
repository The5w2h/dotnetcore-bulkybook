using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyBook.Models;
using BulkyBook.DataAccess;
using Microsoft.AspNetCore.Mvc;
using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess.Repository.IRepository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BulkyBookWeb.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        //private readonly ICategoryRepository _db;
        private readonly IUnitOfWork _unitOfWork;
        // GET: /<controller>/

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            try
            {
                IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();
                return View(objCoverTypeList); // the *IEnumberable*, that is passed to the view, should be added in *@model* inside the *View*
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
        public IActionResult Create(CoverType obj)
        {
            try
            {
               
                if (ModelState.IsValid)
                {
                    _unitOfWork.CoverType.Add(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Cover Type created successfully.";
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
            var coverTypeFromDb = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (coverTypeFromDb == null)
            {
                return NotFound();
            }

            return View(coverTypeFromDb);
            // the *IEnumberable*, that is passed to the view, should be added in *@model* inside the *View*
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    _unitOfWork.CoverType.Update(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Cover Type updated successfully.";
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
            var coverTypeFromDb = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (coverTypeFromDb == null)
            {
                return NotFound();
            }

            return View(coverTypeFromDb);
            // the *IEnumberable*, that is passed to the view, should be added in *@model* inside the *View*
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CoverType obj)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    _unitOfWork.CoverType.Remove(obj);
                    _unitOfWork.Save();
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

