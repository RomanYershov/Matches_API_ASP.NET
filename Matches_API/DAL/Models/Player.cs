using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matches_API.DAL.Models
{
    public class Player : Person
    {
        public int TeamId { get; set; }
        public  Team Team { get; set; }
    }
}