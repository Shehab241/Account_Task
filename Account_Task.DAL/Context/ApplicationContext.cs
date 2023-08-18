using Account_Task.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Task.DAL.Context
{
    public class ApplicationContext: DbContext

    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
        
        }
        
        
        public DbSet<users> Users { get; set; }
        public DbSet<Account> Account { get; set; }
    }
}
