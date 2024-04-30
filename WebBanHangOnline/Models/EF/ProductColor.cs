using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_ProductColor")]
    public class ProductColor
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Title { get; set; }
        public int ProductID { get; set; }
        public int ColorID { get; set; }
        public virtual Product Product { get; set; }
        public virtual Color Color { get; set; }
    }
}