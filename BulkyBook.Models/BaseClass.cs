using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BulkyBook.Models
{
    public class BaseClass
    {
        public BaseClass()
        {
            DateTime Inserted = DateTime.Now;
        }
        [Key]
        public long Id { get; set; }
        public DateTime Inserted { get; set; }
        public long InsertedBy { get; set; }
        public DateTime Updated { get; set; }
        public long UpdatedBy { get; set; }

    }
}