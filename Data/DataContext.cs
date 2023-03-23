using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OptiLoan.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Organization> Organizations => Set<Organization>();
        public DbSet<Agent> Agents => Set<Agent>();
        public DbSet<SuperAgent> SuperAgents => Set<SuperAgent>();
        public DbSet<MasterAgent> MasterAgents => Set<MasterAgent>();
        public DbSet<Staff> Staffs => Set<Staff>();
        
        
        
    }
}