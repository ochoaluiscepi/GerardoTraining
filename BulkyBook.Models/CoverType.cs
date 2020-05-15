using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BulkyBook.Models
{
    public class CoverType : BaseClass
    {
        [Display(Name="Category Name")]
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
    }
}
