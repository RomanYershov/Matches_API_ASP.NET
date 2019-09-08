using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matches_API.DAL.Models
{
    public abstract class Person : Entity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }   
    }
}