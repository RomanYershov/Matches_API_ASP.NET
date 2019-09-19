using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matches_API.DAL.Models
{
    public class Candidate : Person
    {
        public int Age { get; set; }
        public bool Done { get; set; }  
    }
}