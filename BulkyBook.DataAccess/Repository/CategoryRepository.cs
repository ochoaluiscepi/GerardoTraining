using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        public readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            var objFromDB = _db.Category.FirstOrDefault(s=>s.Id ==category.Id);
            if(objFromDB != null)
            {
                objFromDB.Name = category.Name;
                objFromDB.Updated = DateTime.Now;
                objFromDB.UpdatedBy = 0;
            }
        }
    }
}
