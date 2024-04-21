using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    public class Sub
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}