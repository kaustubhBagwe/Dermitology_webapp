﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V01_InnovtionWebAPP.Model
{
    class enquiryModel
    {
        public Int64 id { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string contactNumber { get; set; }
        public string queryMessage { get; set; }
        public string response { get; set; }
        public Boolean respondedUsing { get; set; }
        public string comments { get; set; }
        public DateTime createdOn { get; set; }
        public int updatedBy { get; set; }
        public DateTime updatedOn { get; set; }
        
    }
}
