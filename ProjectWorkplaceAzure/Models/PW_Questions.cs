using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectWorkplaceAzure.Models
{
    public class PW_Questions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        
        [Key]
        public System.Guid QuestionID { get; set; }
        public string QuestionDesc { get; set; }
        public bool IsCommon { get; set; }
        public bool IsMultipleAns { get; set; }
        public bool IsActive { get; set; }

    }
}