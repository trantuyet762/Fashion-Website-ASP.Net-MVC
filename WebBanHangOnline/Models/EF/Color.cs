using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_Color")]
    public class Color
    {
        public Color()
        {
            this.ProductColors = new HashSet<ProductColor>();
            this.ProductQuantities = new HashSet<ProductQuantity>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Title { get; set; }
        public string ColorName { get; set; }
        public ICollection<ProductColor> ProductColors { get; set; }
        public ICollection<ProductQuantity> ProductQuantities { get; set; }
    }
}