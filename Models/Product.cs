using System;
using System.ComponentModel.DataAnnotations;
using ProductAppCore2.Services;

namespace ProductAppCore2.Models
{
    public class Product : IEntity
    {   
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        public int SupplierId { get; set; }

        //Navigation property
        //1 Product belongs to atleast 1 supplier
        public Supplier Supplier { get; set; }
    }
}
