using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UpSert(long? Id)
        {
            
            CoverType Cover = new CoverType();
            if (Id == null)
            {
                return View(Cover);
            }
            Cover = _unitOfWork.CoverType.Get(Id.GetValueOrDefault());
            if (Cover == null)
            {
                return NotFound();
            }
            return View(Cover);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert(CoverType covertype)
        {
            if (ModelState.IsValid)
            {
                if(covertype.Id == 0)
                {
                    covertype.Inserted = DateTime.Now;
                    covertype.InsertedBy = 1;
                    covertype.Updated = DateTime.Now;
                    covertype.UpdatedBy = 1;
                    _unitOfWork.CoverType.Add(covertype);
                }
                else
                {
                    _unitOfWork.CoverType.Update(covertype);
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
        public JsonResult GetAll()
        {
            try
            {
                return Json(new { success =true, data = _unitOfWork.CoverType.GetAll()});
            }
            catch
            {
                return Json(new {success=false, data = new List<CoverType>() });
            }
           
        }
        [HttpDelete]
        public JsonResult Delete(long Id)
        {
            var Cover = _unitOfWork.CoverType.Get(Id);
            if(Cover != null){
                _unitOfWork.CoverType.Remove(Id);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Record has been removed" });
            }
            else
            {
                return Json(new{ success = false, message = "Unable to remove the record" });
            }
            
        }
        #endregion
    }
}