using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matches_API.BLL.Models
{
    public class CandidateModel : ModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool Done { get; set; }  
    }
}