using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWorkplaceAzure.Models
{
    public class PW_PersonTeams
    {
        [Key]
        public System.Guid PersonTeamID { get; set; }
        public System.Guid PersonID { get; set; }
        public Nullable<System.Guid> TeamID { get; set; }
        public Nullable<System.Guid> LeaderID { get; set; }
        public System.DateTime EffectiveDate { get; set; }
        public bool IsActive { get; set; }

    }
}