using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_Category")]
    public class Category: CommonAbstract
    {
        public Category()
        {
            this.New = new HashSet<New>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
       
        public int id { get; set; }
       [Required(ErrorMessage ="Tên danh mục không được để trống")]
       [StringLength(150)]
        public string Title { get; set; }
        
        public string Alias { get; set; }
        /*  [StringLength(150)]
          public string TypeCode { get; set; }
          public string Link { get; set; }*/
        public string Link { get; set; }
        public string Description { get; set; }
        [StringLength(150)]
        public string SeoTitle { get; set; }
        [StringLength(150)]
        public string SeoDescription { get; set; }
        [StringLength(150)]
        public string SeoKeyWords { get; set; }
        public bool IsActive { get; set; }
        public int Position { get; set; }
        public ICollection<New> New { get; set; }
        public ICollection<Post> Post { get; set; }
    }
}