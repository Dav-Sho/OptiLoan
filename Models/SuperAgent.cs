using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptiLoan.Models
{
    public class SuperAgent
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public User? user { get; set; }
        public int UserId { get; set; }
        public int AccountNumber { get; set; }
        public List<Agent>? Agents { get; set; }
        public MasterAgent? MasterAgent { get; set; }
        // public int MasterAgentCode { get; set; }
        public OrganizationClass Class { get; set; }
    }
}