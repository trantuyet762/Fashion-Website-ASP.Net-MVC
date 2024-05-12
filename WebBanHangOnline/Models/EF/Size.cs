using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_Size")]
    public class Size
    {
        public Size()
        {
            this.ProductSizes = new HashSet<ProductSize>();
            this.ProductQuantities = new HashSet<ProductQuantity>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Title { get; set; }
        public string SizeName { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }
        public ICollection<ProductQuantity> ProductQuantities{ get; set; }
    }
}