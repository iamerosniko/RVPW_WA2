using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace ProjectWorkplaceAzure.Models
{
    public partial class PW_ViewEmployeeScore
    {
        [Key]
        public string Username { get; set; }
        public int Score { get; set; }
        public int Items { get; set; }
        public Nullable<System.DateTime> DateCompleted { get; set; }
    }
}