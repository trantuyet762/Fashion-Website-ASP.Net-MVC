using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    public abstract class CommonAbstract
    {
        public string CreateBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Modifieddate { get; set; }
        public string ModifiedBy { get; set; }
    }
}