using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProjectWorkplaceAzure.Models
{
    public class PW_Subjects
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        

        [Key]
        public System.Guid SubjectID { get; set; }
        public string SubjectName { get; set; }
        public bool IsActive { get; set; }

        
    }
}