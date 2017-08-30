using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWorkplaceAzure.Models
{
    public class PW_TeamResources
    {
        [Key]
        public int TeamResourceID { get; set; }
        public System.Guid TeamID { get; set; }
        public System.Guid ResourceID { get; set; }

        
    }
}