using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWorkplaceAzure.Models
{
    public class PW_Examinees
    {
        [Key]
        public System.Guid ExamineeID { get; set; }
        public System.Guid PersonID { get; set; }
        public Nullable<int> CodeNum { get; set; }
        public Nullable<System.Guid> SubjectID { get; set; }
        public Nullable<System.DateTime> DateCompleted { get; set; }
        public int Score { get; set; }
        public int Items { get; set; }
    }
}