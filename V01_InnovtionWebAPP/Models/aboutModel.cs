using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V01_InnovtionWebAPP.Model
{
    public class aboutCategoryModel
    {
        public Int64 id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string degrees { get; set; }
        public Int64 createdby { get; set; }
        public DateTime createdOn { get; set; }
        public Int64 updatedBy { get; set; }
        public DateTime updatedOn { get; set; }
        public Boolean mode { get; set; }
    }

    public class aboutImagesModel
    {
        public Int64 id { get; set; }
        public Int64 catID { get; set; }
        public string imgTitle { get; set; }
        public string imgPath { get; set; }
        public Boolean onHomePage { get; set; }
        public Boolean active { get; set; }
        public Int64 createdby { get; set; }
        public DateTime createdOn { get; set; }
        public Int64 updatedBy { get; set; }
        public DateTime updatedOn { get; set; }
        public Boolean mode { get; set; }
    }
}