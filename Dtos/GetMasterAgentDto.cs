using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptiLoan.Dtos
{
    public class GetMasterAgentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int AccountNumber { get; set; }
        public string  UserClass { get; set; } = string.Empty;
    }
}