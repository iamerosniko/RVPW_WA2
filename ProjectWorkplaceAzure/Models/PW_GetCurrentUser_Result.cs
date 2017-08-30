using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWorkplaceAzure.Models
{
    public partial class PW_GetCurrentUser_Result
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.Guid TeamID { get; set; }
        public int LeaderID { get; set; }
        public string Username { get; set; }
        public int QuizScore { get; set; }
        public int QuizItem { get; set; }
        public bool IsActive { get; set; }
    }
}