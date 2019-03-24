using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace V01_InnovtionWebAPP.Models
{
    [Table("in_ServiceSubCategory")]
    public class ServiceSubCtegory
    {
        [Key]
        public int ServiceSubCategoryID { get; set; }
        public int CategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public string SubCategoryDescrption { get; set; }
        public bool Isctive { get; set; }
        public string SEOMeta { get; set; }
        public string SEOTitle { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LMD { get; set; }

        [ForeignKey("CategoryID")]
        public ServiceCategory FK_Category { get; set; }
    }
}