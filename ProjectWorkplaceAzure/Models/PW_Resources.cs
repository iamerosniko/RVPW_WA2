using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWorkplaceAzure.Models
{
    public class PW_Resources
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        
        [Key]
        public System.Guid ResourceID { get; set; }
        public string ResourceName { get; set; }
        public string ResourcePath { get; set; }
        public string ResourceCategory { get; set; }
        public bool IsUrl { get; set; }

       
    }
}