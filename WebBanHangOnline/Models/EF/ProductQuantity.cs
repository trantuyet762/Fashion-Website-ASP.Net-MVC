using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("ProductQuantity")]
    public class ProductQuantity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }

        public int QuantityProduct { get; set; }

       
        public virtual Product Product { get; set; }

      
        public virtual Size Size { get; set; }

       
        public virtual Color Color { get; set; }
    }
}