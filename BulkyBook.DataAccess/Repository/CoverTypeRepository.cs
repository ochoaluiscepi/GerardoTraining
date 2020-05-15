using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class CoverTypeRepository:Repository<CoverType>,ICoverTypeRepository
    {
        public readonly ApplicationDbContext _db;
        public CoverTypeRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(CoverType covtype)
        {
            var objFromDB = _db.CoverType.FirstOrDefault(s=>s.Id == covtype.Id);
            if(objFromDB != null)
            {
                objFromDB.Name = covtype.Name;
                objFromDB.Updated = DateTime.Now;
                objFromDB.UpdatedBy = 0;
            }
        }
    }
}
