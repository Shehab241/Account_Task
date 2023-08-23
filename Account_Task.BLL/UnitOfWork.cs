using Account_Task.BLL.Interfaces;
using Account_Task.BLL.Repositories;
using Account_Task.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Task.BLL
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly ApplicationContext _context;

        public IAccountRepositories accountRepositories { get ; set ; }
        public IUsersRepositories usersRepositories { get; set; }

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            accountRepositories=new AccountRepositories(context);
            usersRepositories=new UserRepositories(context);
        }

        public async Task<int> Compelete()
        =>   await _context.SaveChangesAsync();

        public void Dispose()
        =>_context.Dispose();
    }
}
