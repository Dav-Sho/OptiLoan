using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptiLoan.Dtos
{
    public class SuperAgentDto
    {
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Account Number is required")]
        public int AccountNumber { get; set; }

        [Required(ErrorMessage = "MasterAgent code required")]
        public int MasterAgentId { get; set; }
    }
}