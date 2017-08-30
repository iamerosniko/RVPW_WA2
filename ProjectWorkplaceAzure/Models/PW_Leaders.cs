using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectWorkplaceAzure.Models
{
    public class PW_Leaders
    {
        [Key]
        public int LeaderID { get; set; }
        public string LeaderName { get; set; }
        public Nullable<int> ManagerID { get; set; }
        public Nullable<System.Guid> LeaderResourceID { get; set; }
        public Nullable<System.Guid> ManagerResourceID { get; set; }
    }
}