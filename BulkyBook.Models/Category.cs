using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BulkyBook.Models
{
    public class Category : BaseClass
    {
        [Display(Name="Category Name")]
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
    }
}
