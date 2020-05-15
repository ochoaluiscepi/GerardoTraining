using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UpSert(long? Id)
        {
            Category category = new Category();
            if (Id == null)
            {
                return View(category);
            }
            category = _unitOfWork.Category.Get(Id.GetValueOrDefault());
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0){
                    category.Inserted = DateTime.Now;
                    category.InsertedBy = 1;
                    category.Updated = DateTime.Now;
                    category.UpdatedBy = 1;
                    _unitOfWork.Category.Add(category);
                }
                else
                {
                    _unitOfWork.Category.Update(category);
                }
                _unitOfWork.Save();
               return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
            
        }

        #region API

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var AllObj = _unitOfWork.Category.GetAll();
                return Json(new { data = AllObj});
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpDelete]
        public IActionResult Delete(long Id)
        {
            var AllObj = _unitOfWork.Category.Get(Id);
            if(AllObj == null)
            {
                return Json(new {success = false, Message = "Error While deleting" });
            }
            _unitOfWork.Category.Remove(Id);
            _unitOfWork.Save();
            return Json(new {success = true, message = "Record deleted" });
        }

        #endregion
    }
}