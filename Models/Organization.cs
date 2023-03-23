using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptiLoan.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public User? user { get; set; }
        public int  UserId { get; set; }
        public List<MasterAgent>? MasterAgents { get; set; }
        public List<Staff>? Staff { get; set; }
        
    }
}