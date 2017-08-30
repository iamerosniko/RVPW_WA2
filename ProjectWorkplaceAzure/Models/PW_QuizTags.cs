using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWorkplaceAzure.Models
{
    public class PW_QuizTags
    {
        [Key]
        public System.Guid QuizTagID { get; set; }
        public System.Guid QuestionID { get; set; }
        public System.Guid SubjectID { get; set; }
        public bool IsActive { get; set; }

        
    }
}