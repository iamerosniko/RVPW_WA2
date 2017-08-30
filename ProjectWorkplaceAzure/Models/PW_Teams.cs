using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWorkplaceAzure.Models
{
    public class PW_Teams
    {
        
        [Key]
        public System.Guid TeamID { get; set; }
        public string TeamDesc { get; set; }
        public bool IsActive { get; set; }

        
    }
}