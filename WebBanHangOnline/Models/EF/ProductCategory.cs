using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity.Spatial;
namespace WebBanHangOnline.Models.EF
{
    [Table("tb_ProductCategory")]
    public class ProductCategory:CommonAbstract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        [Required]
        [StringLength(150)]
        public string Alias { get; set; }
        public string Description { get; set; }
        
        [StringLength(250)]
        public string Icon { get; set; }
      
        [StringLength(250)]
        public string SeoTitle { get; set; }
      
        [StringLength(500)]
        public string SeoDescription { get; set; }
      
        [StringLength(250)]
        public string SeoKeyWords { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ICollection<Product> Products { get; set; }
    }
}