using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    public class ProductSizes:CommonAbstract
    {
        public ProductSizes()
        {
            Products = new HashSet<Product>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
       
        [StringLength(250)]
        public string Title { get; set; }
        [Required]
        [StringLength(150)]
        public string SizeName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}