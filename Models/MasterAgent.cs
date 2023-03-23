using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptiLoan.Models
{
    public class MasterAgent
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public User? user { get; set; }
        public int UserId { get; set; }
        public int AccountNumber { get; set; }
        public List<SuperAgent>? SuperAgents { get; set; }
        public Organization? Organization { get; set; }
        // public int OrganizationCode { get; set; }
        public OrganizationClass Class { get; set; }
        
    }
}