using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWorkplaceAzure.Models
{
    public class PW_Answers
    {
        [Key]
        public System.Guid AnswerID { get; set; }
        public System.Guid QuestionID { get; set; }
        public string AnswerDesc { get; set; }
        public bool IsActive { get; set; }
        public bool IsCorrect { get; set; }
    }
}