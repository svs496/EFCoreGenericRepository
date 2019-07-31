using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProductAppCore2.Services;

namespace ProductAppCore2.Models
{
    public class Supplier : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5), MaxLength(30)]
        [Display(Name = "Supplier Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string City { get; set; }

        [Required]
        [MinLength(8), MaxLength(15)]
        [Display(Name = "Contact Number")]
        public string ContactNo { get; set; }

        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        //Navigation property
        //1 Supplier can supply multiple products
        public ICollection<Product> Products { get; set; }
    }
}