using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OptiLoan.Models
{
    public class Agent
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public User? user { get; set; }
        public int UserId { get; set; }
        public int AccountNumber { get; set; }
        public SuperAgent? SuperAgent { get; set; }
        // public int SuperAgentCode { get; set; }
        public string UserClass { get; set; } = string.Empty;
    }
}