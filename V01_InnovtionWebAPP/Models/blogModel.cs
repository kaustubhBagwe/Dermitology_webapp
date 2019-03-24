using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace V01_InnovtionWebAPP.Model
{
    [Table("in_blogs")]
    public class blogModel
    {
        public Int64 id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string SEOtitle { get; set; }
        public string SEOmeta { get; set; }
        public Boolean onHomePage { get; set; }
        public Boolean active { get; set; }
        public Int64 createdBy { get; set; }
        public DateTime createdOn { get; set; }
        public Int64 updatedBy { get; set; }
        public DateTime updatedOn { get; set; }
        public Boolean mode { get; set; }
    }
}
