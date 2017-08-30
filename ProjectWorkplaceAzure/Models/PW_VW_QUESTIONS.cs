using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectWorkplaceAzure.Models
{
    public partial class PW_VW_QUESTIONS
    {
        [Key]
        public System.Guid QuestionID { get; set; }
        public string QuestionDesc { get; set; }
        public bool IsCommon { get; set; }
        public bool IsMultipleAns { get; set; }
        public bool IsActive { get; set; }
    }
}