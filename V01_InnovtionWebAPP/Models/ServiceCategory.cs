using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace V01_InnovtionWebAPP.Models
{
    [Table("in_ServiceCategory")]
    public class ServiceCategory
    {
        [Key]
        public int ServiceCategory_ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string SEO_Title { get; set; }
        public string SEO_Meta { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime LMD { get; set; }

    }
}