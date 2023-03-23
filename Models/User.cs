using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptiLoan.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
        public Organization? Organization { get; set; }
        public Agent? Agent { get; set; }
        public SuperAgent? SuperAgent { get; set; }
        public MasterAgent? MasterAgent { get; set; }
        public Staff? Staff { get; set; }
        
        
        
        
        
    }
}